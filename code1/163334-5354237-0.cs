                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageFilePath);
                     // Save the image width
                    float width = image.Width;
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(image);
                    // Now find the Image element in the cell and resize it
                    foreach (IElement element in cell.CompositeElements)
                    {
                        // The inserted image is stored in a PdfPTable, so when you find 
                        // the table element just set the table width with the image width, and lock it.
                        PdfPTable tblImg = element as PdfPTable;
                        if (tblImg != null)
                        {
                            tblImg.TotalWidth = width;
                            tblImg.LockedWidth = true;
                        }
                    }
