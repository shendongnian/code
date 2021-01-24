    using (PdfDocument doc = Document.Load<PdfDocument>("D:\\sample.pdf"))
    {
            // Add text watermark
            TextWatermark watermark = new TextWatermark("Protected Document", new Font("Arial", 8));
            watermark.HorizontalAlignment = HorizontalAlignment.Center;
            watermark.VerticalAlignment = VerticalAlignment.Bottom;
            doc.AddWatermark(watermark);
    
            // Add image watermark
            ImageWatermark imageWatermark = new ImageWatermark("D:\\watermark.png");
            imageWatermark.HorizontalAlignment = HorizontalAlignment.Center;
            imageWatermark.VerticalAlignment = VerticalAlignment.Bottom;
            doc.AddWatermark(imageWatermark);
    
            // Save document
            doc.Save("D:\\output.pdf");
    }
