    var formatting = (((field.Where(item => item.Key == "/AA")
                                  .Select(item => item.Value)
                                  .First() as PdfDictionary).Where(item => item.Key == "/F")
                                                            .Select(item => item.Value)
                                                            .First() as PdfSharp.Pdf.Advanced.PdfReference).Value as PdfDictionary).Where(item => item.Key == "/JS")
                                                                                                           .Select(item => item.Value).First() as PdfString;
