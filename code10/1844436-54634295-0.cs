 foreach (var item in ListCars.OrderBy(x => x.Destiny))
                {
                    Document document= new Document(PageSize.A4, 0f, 0f, 15f, 0f);
                    Image Img = null;
                    FileStream fsData = null;
                    Img = Image.GetInstance(Properties.Resources.CMODEL, System.Drawing.Imaging.ImageFormat.Png);
                    Img.ScaleToFit(PageSize.A4);
                    Img.Alignment = Image.UNDERLYING | Image.ALIGN_CENTER;
                    string DataForTest = "";
                    string PDFName = "TEST - " + item.Vin + ".PDF";
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Rems\Pages\");
                    fsData = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Rems\Pages\" + PDFName, FileMode.Create);
                    PdfWriter writer = PdfWriter.GetInstance(document, fsData);
                    document.Open();
                    PdfContentByte cb = writer.DirectContent;
                    ColumnText ct = new ColumnText(cb);
                    Phrase DataForTestT = new Phrase(DataForTest, FontFactory.GetFont("IMPACT", 8));
                    ct.SetSimpleColumn(DataForTestT, 115, 824, 561, 307, 8, Element.ALIGN_LEFT);
                    ct.Go();
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Rems\Pages\" + PDFName);
                    document.Add(Img);
                    document.AddCreationDate();
                    document.Close();
                }
