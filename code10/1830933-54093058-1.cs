       internal static void Test()
        {
            var doc = new Documents
            {
                Document = new Document
                {
                    Keys = new Keys
                    {
                        Drawer = "GraphicData",
                        SomeData = "otherData"
                    },
                    OtherGenericProperties = new OtherGenericProperties { Data = "GenericData 2" },
                    ListRepeat = new List<Repeat>
                    {
                        new Repeat { FileInfo =new FileInfo { Href = "PdfFile.pdf", MimeType = "application/pdf" } },
                        new Repeat { FileInfo = new FileInfo { Href = "PdfFile2.pdf", MimeType = "application/pdf" } }
                    }
                }
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Documents));
            using (var f = new StreamWriter("D:\\doc.xml", false, Encoding.GetEncoding("Windows-1252")))
            {
                serializer.Serialize(f, doc);
                f.Flush();
            }
        }
