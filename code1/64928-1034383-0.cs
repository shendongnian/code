    public void Print(List<Uri> ListToBePrinted)
    {
        XpsDocumentWriter writer =
            PrintQueue.CreateXpsDocumentWriter(this.SelectedPrinter.PrintQueue);
        PrintCapabilities printerCapabilities =
            this.SelectedPrinter.PrintQueue.GetPrintCapabilities();
        Size PrintableImageSize =
            new Size(printerCapabilities.PageImageableArea.ExtentWidth,
                     printerCapabilities.PageImageableArea.ExtentHeight);
        foreach (Uri aUri in ListToBePrinted)
        {
            DrawingVisual drawVisual = new DrawingVisual();
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(aUri);
            imageBrush.Stretch = Stretch.Fill;
            imageBrush.TileMode = TileMode.None;
            imageBrush.AlignmentX = AlignmentX.Center;
            imageBrush.AlignmentY = AlignmentY.Center;
            using (DrawingContext drawingContext = drawVisual.RenderOpen())
            {
                // Flips along X and Y axis (flips and mirrors)
                drawingContext.PushTransform(new ScaleTransform(-1, 1, PrintableImageSize.Width / 2, PrintableImageSize.Height / 2));
                drawingContext.PushTransform(new RotateTransform(180, PrintableImageSize.Width / 2, PrintableImageSize.Height / 2)); // Rotates 180 degree
                drawingContext.DrawRectangle(imageBrush, null, new Rect(25, -25, PrintableImageSize.Width, PrintableImageSize.Height));
            }
            writer.Write(drawVisual);
        }
    }
