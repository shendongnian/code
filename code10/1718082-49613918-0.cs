                        PdfPCell notesCell = new PdfPCell()
                    {
                        BorderWidthLeft = 0,
                        BorderWidthRight = 0,
                        BorderWidthTop = 0,
                        BorderWidthBottom = .5f
                    };
                    //Notes Cell Rectangle
                    float llxNotes = notesCell.GetLeft(0);
                    float llyNotes = notesCell.GetBottom(0);
                    float urxNotes = notesCell.GetRight(0);
                    float uryNotes = notesCell.GetTop(0);
                    //Notes Duplicate
                    string fieldNotesName = "tfQuoteNotes";
                    TextField tField = new TextField(writer, new iTextSharp.text.Rectangle(llxNotes, llyNotes, urxNotes, uryNotes), fieldNotesName)
                    {
                        FieldName = fieldNotesName
                    };
                    tField.SetRotationFromPage(doc.PageSize); //Needed since this page is rotated 90 from the first page
                    iTextSharp.text.pdf.events.FieldPositioningEvents events = new iTextSharp.text.pdf.events.FieldPositioningEvents(writer, tField.GetTextField());
                    writer.AddAnnotation(tField.GetTextField());
                    notesCell.CellEvent = events; //This somehow ignores the original rectangle (0,0,0,0) in the TextField definition above and changes it to the cell's rectangle
