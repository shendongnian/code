    Document doc = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE, 25, 25, 43, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\test\\Updated_INVOICE#" + textBox45.Text + ".pdf", FileMode.Create));
                doc.Open();
                var myFont11 = FontFactory.GetFont("NewJune", 18, BaseColor.BLACK);
                var p1 = new Paragraph("AK TRAVEL GLOBAL LTD.\n", myFont11);
                doc.Add(p1);
                var AddFont = FontFactory.GetFont("NewJune", 8, BaseColor.BLACK);
                var p23 = new Paragraph("91 HIGH ST\nDUDLEY DY1 1QP\nPhone 01384 255777  Fax 08714 310690", AddFont);
                p23.Alignment = 23;
                doc.Add(p23);
                var myFont = FontFactory.GetFont("NewJune", 12, BaseColor.BLACK);
                var myFont1 = FontFactory.GetFont("NewJune", 30, BaseColor.GRAY);
                var p2 = new Paragraph("INVOICE\n\n", myFont1);
                p2.Alignment = 2;
                doc.Add(p2);
                var p3 = new Paragraph("INVOICE # " + textBox45.Text.ToString() + "\n", myFont);
                p3.Alignment = 2;
                doc.Add(p3);
                var p4 = new Paragraph("DATE: " + DateTime.Now.ToString(), myFont);
                p4.Alignment = 2;
                doc.Add(p4);
                var myFont12 = FontFactory.GetFont("NewJune", 26, BaseColor.BLACK);
                var pg1 = new Paragraph("BILL NUMBER - " + textBox45.Text, myFont12);
                pg1.Alignment = 1;
                doc.Add(pg1);
                PdfPTable table1 = new PdfPTable(2);
                table1.SpacingBefore = 50;
                var myFont111 = FontFactory.GetFont("NewJune", 25, BaseColor.BLACK);
                table1.AddCell(new PdfPCell(new Phrase("TO:", myFont111)));
                table1.AddCell(new PdfPCell(new Phrase("SHIP TO:", myFont111)));
                table1.AddCell(getCell("", PdfPCell.ALIGN_LEFT));
                table1.AddCell(getCell("", PdfPCell.ALIGN_RIGHT));
                table1.AddCell(getCell(textBox53.Text, PdfPCell.ALIGN_LEFT));
                table1.AddCell(getCell(textBox50.Text, PdfPCell.ALIGN_RIGHT));
                table1.AddCell(getCell(textBox52.Text, PdfPCell.ALIGN_LEFT));
                table1.AddCell(getCell(textBox49.Text, PdfPCell.ALIGN_RIGHT));
                table1.AddCell(getCell(textBox51.Text, PdfPCell.ALIGN_LEFT));
                table1.AddCell(getCell(textBox48.Text, PdfPCell.ALIGN_RIGHT));
                table1.AddCell(getCell("", PdfPCell.ALIGN_LEFT));
                table1.AddCell(getCell(textBox47.Text, PdfPCell.ALIGN_RIGHT));
                doc.Add(table1);
                PdfPTable table = new PdfPTable(6);
                table.SpacingBefore = 20;
                table.DefaultCell.BorderWidth = 2;
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell cell = new PdfPCell(new Phrase("ITEM"));
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);
                PdfPCell cell1 = new PdfPCell(new Phrase("DESCRIPTION"));
                cell1.Colspan = 3;
                cell1.HorizontalAlignment = 1;
                table.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("UNIT PRICE"));
                cell2.HorizontalAlignment = 1;
                table.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("TOTAL"));
                cell3.HorizontalAlignment = 1;
                table.AddCell(cell3);
                //New Row
                PdfPCell cell4 = new PdfPCell(new Phrase(textBox41.Text.ToString()));
                cell4.HorizontalAlignment = 1;
                //cell4.Rowspan = 5;
                table.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(textBox43.Text.ToString() + "KG\n" + textBox40.Text.ToString()));
                cell5.HorizontalAlignment = 0;
                cell5.Colspan = 3;
                //cell5.Rowspan = 5;
                table.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase(textBox44.Text.ToString()));
                cell6.HorizontalAlignment = 1;
                //cell6.Rowspan = 5;
                table.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("£" + textBox42.Text.ToString()));
                cell7.HorizontalAlignment = 1;
                //cell7.Rowspan = 5;
                table.AddCell(cell7);
                //New Row
                PdfPCell cell34 = new PdfPCell(new Phrase(textBox67.Text.ToString()));
                cell34.HorizontalAlignment = 1;
                //cell4.Rowspan = 5;
                table.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase(textBox69.Text.ToString() + "KG\n" + textBox66.Text.ToString()));
                cell35.HorizontalAlignment = 0;
                cell35.Colspan = 3;
                //cell5.Rowspan = 5;
                table.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase(textBox70.Text.ToString()));
                cell36.HorizontalAlignment = 1;
                //cell6.Rowspan = 5;
                table.AddCell(cell36);
                PdfPCell cell37 = new PdfPCell(new Phrase("£" + textBox68.Text.ToString()));
                cell37.HorizontalAlignment = 1;
                //cell7.Rowspan = 5;
                table.AddCell(cell37);
                //new row
                PdfPCell cell8 = new PdfPCell(new Phrase("SUBTOTAL"));
                cell8.HorizontalAlignment = 2;
                cell8.Colspan = 5;
                table.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase("£" + textBox37.Text.ToString()));
                cell9.HorizontalAlignment = 1;
                table.AddCell(cell9);
                PdfPCell cell10 = new PdfPCell(new Phrase("BAG"));
                cell10.HorizontalAlignment = 2;
                cell10.Colspan = 5;
                table.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("£" + (float.Parse(textBox36.Text.ToString()) * 3).ToString()));
                cell11.HorizontalAlignment = 1;
                table.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("SHIPPING & HANDLING"));
                cell12.HorizontalAlignment = 2;
                cell12.Colspan = 5;
                table.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("£" + textBox39.Text.ToString()));
                cell13.HorizontalAlignment = 1;
                table.AddCell(cell13);
                PdfPCell cell14 = new PdfPCell(new Phrase("TOTAL DUE"));
                cell14.HorizontalAlignment = 2;
                cell14.Colspan = 5;
                table.AddCell(cell14);
                PdfPCell cell15 = new PdfPCell(new Phrase("£" + textBox38.Text.ToString()));
                cell15.HorizontalAlignment = 1;
                table.AddCell(cell15);
                doc.Add(table);
                var mFont = FontFactory.GetFont("NewJune", 18, BaseColor.BLACK);
                var pr = new Paragraph("\n\nTerms & Conditions\n", mFont);
                doc.Add(pr);
                RomanList romanList = new RomanList(true, 20);
                romanList.IndentationLeft = 30f;
                var lFont = FontFactory.GetFont("NewJune", 8, BaseColor.BLACK);
                char[] diff = { '#' };
                string cat = string.Empty;
                foreach (InvoiceModel invc in Invoices_lst)
                {
                    if (invc.InvoiceNo == textBox45.Text)
                        cat = invc.cat;
                }
                if (cat == "air")
                {
                    q = air_inv;
                }
                else
                {
                    q = sea_inv;
                }
                string[] words = q.Split(diff);
                for (int i = 0; i < words.Length; i++)
                {
                    romanList.Add(new ListItem(words[i], lFont));
                }
                doc.Add(romanList);
                doc.Close();
