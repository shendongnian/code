    using DocumentFormat.OpenXml.Packaging;
    using System.IO;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Wordprocessing;
    public class MyReport
    {
        private MainDocumentPart _mainDocumentPart;
        public void CreateReport()
        {
            using (WordprocessingDocument wpDocument = WordprocessingDocument.Create(@"TempPath\MyReport.docx", WordprocessingDocumentType.Document))
            {
                _mainDocumentPart = wpDocument.AddMainDocumentPart();
                _mainDocumentPart.Document = new Document(new Body());
                AttachFile(@"MyFilePath\MyFile.pdf", true);
            }
        }
        private void AttachFile(string filePathAndName, bool displayAsIcon)
        {
            FileInfo fileInfo = new FileInfo(filePathAndName);
            OpenXmlHelper.AppendEmbeddedObject(_mainDocumentPart, fileInfo, displayAsIcon);
        }
    }
