     public string SaveFiles(PDFFormatModel pd)
        {
            PdfPTable table = new PdfPTable(2);
            PdfPCell cell = new PdfPCell(new Phrase("Cell Name"));
            cell.Colspan = 2;
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            table.AddCell(cell);
            table.AddCell("Cell 1 ");
            table.AddCell("Cell 1 Value");
            table.AddCell("Cell 2 ");
            table.AddCell("Cell 2 Value");
           
           
            var pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Java.IO.File myDir = new Java.IO.File(root + "/MAMN");
            myDir.Mkdir();
            Java.IO.File file = new Java.IO.File(myDir, pd.FileName);
            if (file.Exists()) file.Delete();
            using (var memoryStream = new System.IO.MemoryStream())
            {
                FileOutputStream outs = new FileOutputStream(file);
                var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                pdfDoc.Add(table);
               
                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var filePath = Path.Combine(root, pd.FileName);            
                outs.Write(bytes);
                outs.Flush();
                outs.Close();
                if (file.Exists())
                {
                    Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                    string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                    string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType(path, mimeType);
                    Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
                }             
                    return filePath;
            }       
        }
 
