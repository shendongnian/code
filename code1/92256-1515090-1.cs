        private static PdfPTable GetHFCell(string header, string footer, string text)
        {
            PdfPTable pdft;
            PdfPCell hc;
            PdfPCell fc;
            pdft = new PdfPTable(1);
            pdft.WidthPercentage = 100f;
            pdft.DefaultCell.Border = 0;
            hc = new PdfPCell(new Phrase(header));
            hc.Top = 0f;
            hc.FixedHeight = 7f;
            hc.HorizontalAlignment = 1;
            hc.BackgroundColor = iTextSharp.text.Color.ORANGE;
            ((Chunk)(hc.Phrase[0])).Font = new iTextSharp.text.Font(((Chunk)(hc.Phrase[0])).Font.Family, 5f);
            
            fc = new PdfPCell(new Phrase(footer));
            hc.Top = 0f;
            fc.FixedHeight = 7f;
            hc.HorizontalAlignment = 1;
            fc.BackgroundColor = iTextSharp.text.Color.YELLOW;
            ((Chunk)(fc.Phrase[0])).Font = new iTextSharp.text.Font(((Chunk)(fc.Phrase[0])).Font.Family, 5f);
            pdft.AddCell(hc);
            pdft.AddCell(text);
            pdft.AddCell(fc);
            return pdft;
        }
        public void GeneratePDF()
        {
            Document document = new Document();
            try
            {            
                PdfWriter.GetInstance(document, new FileStream("File1.pdf", FileMode.Create));
                document.Open();
                PdfPTable table = new PdfPTable(5);
                table.DefaultCell.Padding = 0;
                table.DefaultCell.BorderWidth = 2f;
                for (int j = 1; j < 6; j++)
                {
                    for (int i = 1; i < 6; i++)
                    {
                        //calling GetHFCell
                        table.AddCell(
                            GetHFCell("header " + ((int)(i + 5 * (j - 1))).ToString(), 
                                      "footer " + ((int)(i + 5 * (j - 1))).ToString(), 
                                      "z" + j.ToString() + i.ToString()));
                    }
                }
                document.Add(table);
            }
            catch (DocumentException de)
            {
                //...
            }
            catch (IOException ioe)
            {
                //...
            }
            document.Close();
        }
