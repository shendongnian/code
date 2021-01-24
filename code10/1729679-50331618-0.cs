    public class PDFCreatorHelper
    {
        public string ErrorText { get; private set; }
        public string CreatedFile { get; private set; }
        private bool _isTypeInitialized;
        private pdfforge.PDFCreator.UI.ComWrapper.Queue CreateQueue()
        {
            // This needs to be done once to make the ComWrapper work reliably.
            if (!_isTypeInitialized)
            {
                Type queueType = Type.GetTypeFromProgID("PDFCreator.JobQueue");
                Activator.CreateInstance(queueType);
                _isTypeInitialized = true;
            }
            return new pdfforge.PDFCreator.UI.ComWrapper.Queue();
        }
        public void PrintSheet(Worksheet xlSheet, Microsoft.Office.Interop.Excel.Application app, string file)
        {
            ErrorText = null;
            var jobQueue = CreateQueue();
            string folder = Path.GetDirectoryName(file);
            string filename = Path.GetFileNameWithoutExtension(file);
            string convertedFilePath = Path.Combine(folder, filename + ".pdf");
            try
            {
                jobQueue.Initialize();
                //Actual print command
                xlSheet.PrintOutEx(Type.Missing, Type.Missing, Type.Missing, Type.Missing, "PDFCreator", Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                if (!jobQueue.WaitForJob(10))
                {
                    ErrorText = string.Format("PDFCreator: tisk {0} nebyl spuštěn do 10 sekund.", file);
                }
                else
                {
                    var printJob = jobQueue.NextJob;                    
                    printJob.SetProfileByGuid("DefaultGuid");
                    printJob.ConvertTo(convertedFilePath);
                    if (!printJob.IsFinished || !printJob.IsSuccessful)
                    {
                        ErrorText = string.Format("PDFCreator: nepodařila se konverze souboru: {0}.", file);
                    }
                }
            }
            catch (Exception err)
            {
                ErrorText = err.Message;
            }
            finally
            {
                CreatedFile = convertedFilePath;
                jobQueue.ReleaseCom();
            }
        }
    }
