    public static class PDFCreatorHelper
    {
        public static string ErrorText { get; private set; }
        public static string CreatedFile { get; private set; }
        private static pdfforge.PDFCreator.UI.ComWrapper.Queue jobQueue = null;
        public static void PrintSheet(Worksheet xlSheet, Microsoft.Office.Interop.Excel.Application app, string file)
        {
            ErrorText = null;
            CreatedFile = null;
            if (jobQueue == null) 
            {
                Type queueType = Type.GetTypeFromProgID("PDFCreator.JobQueue");
                Activator.CreateInstance(queueType);
                jobQueue = new pdfforge.PDFCreator.UI.ComWrapper.Queue();
                jobQueue.Initialize();  //Reusing one instance for the application runtime
            }
            else
            {
                jobQueue.Clear(); //Delete jobs already put there
            }
            string folder = Path.GetDirectoryName(file);
            string filename = Path.GetFileName(file);
            string convertedFilePath = Path.Combine(folder, filename);
            try
            {
                //Actual print command
                xlSheet.PrintOutEx(Type.Missing, Type.Missing, Type.Missing, Type.Missing, "PDFCreator", Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                if (!jobQueue.WaitForJob(10))
                {
                    ErrorText = string.Format("PDFCreator: tisk {0} nebyl spuštěn do 10 sekund.", file);
                    Tools.LogError(ErrorText);
                }
                else
                {
                    var printJob = jobQueue.NextJob;
                    printJob.SetProfileByGuid("DefaultGuid");
                    printJob.SetProfileSetting("OpenViewer","false");
                    printJob.SetProfileSetting("OpenWithPdfArchitect", "false");
                    printJob.SetProfileSetting("ShowProgress", "false");
                    printJob.SetProfileSetting("TargetDirectory", folder);
                    printJob.SetProfileSetting("ShowAllNotifications", "false");
                    if (File.Exists(convertedFilePath)) File.Delete(convertedFilePath);
                    printJob.ConvertTo(convertedFilePath);
                    if (!printJob.IsFinished || !printJob.IsSuccessful)
                    {
                        ErrorText = string.Format("PDFCreator: nepodařila se konverze souboru: {0}.", file);
                        Tools.LogError(ErrorText);
                    }
                    printJob = null;
                }
            }
            catch (Exception err)
            {
                Tools.LogException(err, "PDFCreator");
                ErrorText = err.Message;
            }
            finally
            {
                CreatedFile = convertedFilePath;
                //If this is left uncommented, app hangs during the second run
                //jobQueue.ReleaseCom(); 
                //jobQueue = null;
            }
        }
    }
