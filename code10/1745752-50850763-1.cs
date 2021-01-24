                //generate pdf
                using (Doc pdfDocument = new Doc())
                {
                    // Set HTML options
                    pdfDocument.HtmlOptions.Engine      = EngineType.Gecko;
                    pdfDocument.HtmlOptions.Media       = MediaType.Screen;
                    // Convert first HTML page, result: html string
                    int         pageID                  = pdfDocument.AddImageHtml(result);
                    // Convert other HTML pages
                    while (true)
                    {
                        if (!pdfDocument.Chainable(pageID))
                        {
                            break;
                        }
                        pdfDocument.Page                = pdfDocument.AddPage();
                        pageID                          = pdfDocument.AddImageToChain(pageID);
                    }
                    //save
                    for (int i = 0; i < pdfDocument.PageCount; i++)
                    {
                        pdfDocument.PageNumber          = i;
                        pdfDocument.Flatten();
                    }
                    //save the pdf, pdfFullPath: path to save the pdf
                    pdfDocument.Save(pdfFullPath);
                }
