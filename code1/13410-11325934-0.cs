        /// <summary>
        /// Initializes a new instance of the <see cref="PdfFilePrinter"/> class.
        /// </summary>
        public PdfFilePrinter()
        {
            adobeReaderPath = @"C:\Program Files\Adobe\Reader 9.0\Reader\AcroRd32.exe";
            printerName = "HP LaserJet P2055 Series PCL6";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfFilePrinter"/> class.
        /// </summary>
        /// <param name="pdfFileName">Name of the PDF file.</param>
        public PdfFilePrinter(string pdfFileName)
        {
            this.PdfFileName = pdfFileName;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfFilePrinter"/> class.
        /// </summary>
        /// <param name="pdfFileName">Name of the PDF file.</param>
        /// <param name="printerName">Name of the printer.</param>
        public PdfFilePrinter(string pdfFileName, string printerName)
        {
            this.pdfFileName = pdfFileName;
            this.printerName = printerName;
        }
        /// <summary>
        /// Gets or sets the name of the PDF file to print.
        /// </summary>
        public string PdfFileName
        {
            get { return this.pdfFileName; }
            set { this.pdfFileName = value; }
        }
        string pdfFileName;
        /// <summary>
        /// Gets or sets the name of the printer. A typical name looks like '\\myserver\HP LaserJet PCL5'.
        /// </summary>
        /// <value>The name of the printer.</value>
        public string PrinterName
        {
            get { return this.printerName; }
            set { this.printerName = value; }
        }
        string printerName;
        /// <summary>
        /// Gets or sets the working directory.
        /// </summary>
        public string WorkingDirectory
        {
            get { return this.workingDirectory; }
            set { this.workingDirectory = value; }
        }
        string workingDirectory;
        /// <summary>
        /// Prints the PDF file.
        /// </summary>
        public void Print()
        {
            Print(-1);
        }
        /// <summary>
        /// Prints the PDF file.
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait for completing the print job.</param>
        public void Print(int milliseconds)
        {
            if (this.printerName == null || this.printerName.Length == 0)
                this.printerName = PdfFilePrinter.defaultPrinterName;
            if (PdfFilePrinter.adobeReaderPath == null || PdfFilePrinter.adobeReaderPath.Length == 0)
                throw new InvalidOperationException("No full qualified path to AcroRd32.exe or Acrobat.exe is set.");
            if (this.printerName == null || this.printerName.Length == 0)
                throw new InvalidOperationException("No printer name set.");
            // Check whether file exists.
            string fqName = String.Empty;
            if (this.workingDirectory != null && this.workingDirectory.Length != 0)
                fqName = Path.Combine(this.workingDirectory, this.pdfFileName);
            else
                fqName = Path.Combine(Directory.GetCurrentDirectory(), this.pdfFileName);
            if (!File.Exists(fqName))
                throw new InvalidOperationException(String.Format("The file {0} does not exist.", fqName));
            // TODO: Check whether printer exists.
            try
            {
                DoSomeVeryDirtyHacksToMakeItWork();
                //acrord32.exe /t          <- seems to work best
                //acrord32.exe /h /p       <- some swear by this version
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = PdfFilePrinter.adobeReaderPath;
                string args = String.Format("/t \"{0}\" \"{1}\"", this.pdfFileName, this.printerName);
                //Debug.WriteLine(args);
                startInfo.Arguments = args;
                startInfo.CreateNoWindow = true;
                startInfo.ErrorDialog = false;
                startInfo.UseShellExecute = false;
                if (this.workingDirectory != null && this.workingDirectory.Length != 0)
                    startInfo.WorkingDirectory = this.workingDirectory;
                Process process = Process.Start(startInfo);
                if (!process.WaitForExit(milliseconds))
                {
                    // Kill Adobe Reader/Acrobat
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// For reasons only Adobe knows the Reader seams to open and shows the document instead of printing it
        /// when it was not already running.
        /// If you use PDFsharp and have any suggestions to circumvent this function, please let us know.
        /// </summary>
        void DoSomeVeryDirtyHacksToMakeItWork()
        {
            if (PdfFilePrinter.runningAcro != null)
            {
                if (!PdfFilePrinter.runningAcro.HasExited)
                    return;
                PdfFilePrinter.runningAcro.Dispose();
                PdfFilePrinter.runningAcro = null;
            }
            // Is any Adobe Reader/Acrobat running?
            Process[] processes = Process.GetProcesses();
            int count = processes.Length;
            for (int idx = 0; idx < count; idx++)
            {
                try
                {
                    Process process = processes[idx];
                    ProcessModule module = process.MainModule;
                    if (String.Compare(Path.GetFileName(module.FileName), Path.GetFileName(PdfFilePrinter.adobeReaderPath), true) == 0)
                    {
                        // Yes: Fine, we can print.
                        PdfFilePrinter.runningAcro = process;
                        break;
                    }
                }
                catch { }
            }
            if (PdfFilePrinter.runningAcro == null)
            {
                // No: Start an Adobe Reader/Acrobat.
                // If you are within ASP.NET, good luck...
                PdfFilePrinter.runningAcro = Process.Start(PdfFilePrinter.adobeReaderPath);
                PdfFilePrinter.runningAcro.WaitForInputIdle();
            }
        }
        static Process runningAcro;
        /// <summary>
        /// Gets or sets the Adobe Reader or Adobe Acrobat path.
        /// A typical name looks like 'C:\Program Files\Adobe\Adobe Reader 7.0\AcroRd32.exe'.
        /// </summary>
        static public string AdobeReaderPath
        {
            get { return PdfFilePrinter.adobeReaderPath; }
            set { PdfFilePrinter.adobeReaderPath = value; }
        }
        static string adobeReaderPath;
        /// <summary>
        /// Gets or sets the name of the default printer. A typical name looks like '\\myserver\HP LaserJet PCL5'.
        /// </summary>
        static public string DefaultPrinterName
        {
            get { return PdfFilePrinter.defaultPrinterName; }
            set { PdfFilePrinter.defaultPrinterName = value; }
        }
        static string defaultPrinterName;
    }
