        using Microsoft.Office.Interop.Word;
        using System.Runtime.InteropServices;
        using System.IO;
        using Microsoft.Office.Core;Application app;
        public string CreatePDF(string path, string exportDir)
        {
            Application app = new Application();
            app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            app.Visible = true;
            var objPresSet = app.Documents;
            var objPres = objPresSet.Open(path, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
            var baseFileName = Path.GetFileNameWithoutExtension(path);
            var pdfFileName = baseFileName + ".pdf";
            var pdfPath = Path.Combine(exportDir, pdfFileName);
            try
            {
                objPres.ExportAsFixedFormat(
                    pdfPath,
                    WdExportFormat.wdExportFormatPDF,
                    false,
                    WdExportOptimizeFor.wdExportOptimizeForPrint,
                    WdExportRange.wdExportAllDocument
                );
            }
            catch
            {
                pdfPath = null;
            }
            finally
            {
                objPres.Close();
            }
            return pdfPath;
        }
