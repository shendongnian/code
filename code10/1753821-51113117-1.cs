    void Copy(PdfReader source, string sourceButton, PdfStamper target, string targetButton)
    {
        PdfStream xObject = (PdfStream) PdfReader.GetPdfObjectRelease(source.AcroFields.GetNormalAppearance(sourceButton));
        PdfDictionary resources = xObject.GetAsDict(PdfName.RESOURCES);
        ImageRenderListener strategy = new ImageRenderListener();
        PdfContentStreamProcessor processor = new PdfContentStreamProcessor(strategy);
        processor.ProcessContent(ContentByteUtils.GetContentBytesFromContentObject(xObject), resources);
        System.Drawing.Image drawingImage = strategy.Images.First();
        Image image = Image.GetInstance(drawingImage, drawingImage.RawFormat);
        PushbuttonField button = target.AcroFields.GetNewPushbuttonFromField(targetButton);
        button.Image = image;
        target.AcroFields.ReplacePushbuttonField(targetButton, button.Field);
    }
