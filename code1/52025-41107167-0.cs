    internal static byte[] mergePdfs(byte[] pdf1, byte[] pdf2,byte[] pdf3)
            {
                MemoryStream outStream = new MemoryStream();
                using (Document document = new Document())
                using (PdfCopy copy = new PdfCopy(document, outStream))
                {
                    document.Open();
                    copy.AddDocument(new PdfReader(pdf1));
                    copy.AddDocument(new PdfReader(pdf2));
                    copy.AddDocument(new PdfReader(pdf3));
                }
                return outStream.ToArray();
            } 
