    public void AddImage(int pageNumber)
            {
                if (pageNumber > 0)
                {
                    string pdfTemplate =
    
        @"D:\Input.pdf";
    
    
                    string newFile = @"D:\Output.pdf";
                    PdfReader pdfReader = new PdfReader(pdfTemplate);
    
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(
                    newFile, FileMode.Create));
    
                    AcroFields pdfFormFields = pdfStamper.AcroFields;
                    string chartLoc = string.Empty;
    
                    chartLoc = @"C:\img.png";
    
                    iTextSharp.text.Image chartImg = iTextSharp.text.Image.GetInstance(chartLoc);
                    iTextSharp.text.pdf.PdfContentByte underContent;
    
                    iTextSharp.text.Rectangle rect;
                    try
    
                    {
    
                        Single X, Y; int pageCount = 0;
                        rect = pdfReader.GetPageSizeWithRotation(1);
    
                        if (chartImg.Width > rect.Width || chartImg.Height > rect.Height)
                        {
    
                            chartImg.ScaleToFit(rect.Width, rect.Height);
    
                            X = (rect.Width - chartImg.ScaledWidth) / 2;
    
                            Y = (rect.Height - chartImg.ScaledHeight) / 2;
    
                        }
    
                        else
    
                        {
    
                            X = (rect.Width - chartImg.Width) / 2;
    
                            Y = (rect.Height - chartImg.Height) / 2;
    
                        }
                        chartImg.SetAbsolutePosition(X, Y);
    
                        pageCount = pdfReader.NumberOfPages;
    //Below to add image to all pages
                        //for (int i = 1; i < pageCount; i++)
                        //{
    
                        //    underContent = pdfStamper.GetOverContent(i);//.GetUnderContent(i);
    
                        //    underContent.AddImage(chartImg);
    
                        //}
    
                        if (pageCount >= pageNumber)
                        {
                            underContent = pdfStamper.GetOverContent(pageNumber);//.GetUnderContent(i);
    
                            underContent.AddImage(chartImg);
                        }
    
    
    
    
    
                        pdfStamper.Close();
    
                        pdfReader.Close();
    
                    }
    
                    catch (Exception ex)
                    {
    
                        throw ex;
                    }
                }
            }
