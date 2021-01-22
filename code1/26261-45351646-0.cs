    public static byte[] CombineMultipleByteArrays(List<byte[]> lstByteArray)
            {
                using (var ms = new MemoryStream())
                {
                    using (var doc = new iTextSharp.text.Document())
                    {
                        using (var copy = new PdfSmartCopy(doc, ms))
                        {
                            doc.Open();
                            foreach (var p in lstByteArray)
                            {
                                using (var reader = new PdfReader(p))
                                {
                                    copy.AddDocument(reader);
                                }
                            }
    
                            doc.Close();
                        }
                    }
                    return ms.ToArray();
                }
            }
