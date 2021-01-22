    XpsDocument xpsDoc = new XpsDocument(xpsFileName, System.IO.FileAccess.Read);
    FixedDocumentSequence docSeq = xpsDoc.GetFixedDocumentSequence();
    const double scaleFactor = 0.8;
    for (int pageNum = 0; pageNum < docSeq.DocumentPaginator.PageCount; pageNum++)
    {
        DocumentPage docPage = docSeq.DocumentPaginator.GetPage(pageNum);
                
        RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)Math.Round(scaleFactor * docPage.Size.Width),
                    (int)Math.Round(scaleFactor * docPage.Size.Height), (int)Math.Round(scaleFactor * 96), (int)Math.Round(scaleFactor * 96), PixelFormats.Default);
        renderTarget.Render(docPage.Visual);
                
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.QualityLevel = 75;
        // Choose type here ie: JpegBitmapEncoder, etc
        //BitmapEncoder encoder = new PngBitmapEncoder();  // Choose type here ie: JpegBitmapEncoder, etc
        encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                
        string pageImageFileName = string.Format("{0}-{1}.jpg", Path.Combine(Path.GetDirectoryName(xpsFileName), Path.GetFileNameWithoutExtension(xpsFileName)), pageNum);
                using (FileStream pageOutStream = new FileStream(pageImageFileName, FileMode.Create, FileAccess.Write))
        {
            encoder.Save(pageOutStream);
        }
    }
