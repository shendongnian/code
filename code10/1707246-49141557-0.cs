    using (var output = new MemoryStream())
    {
        using (var pdfWriter = new PdfWriter(output))
        {
            // You need to set this to false to prevent the stream
            // from being closed.
            pdfWriter.SetCloseStream(false);
            using (var pdfDocument = new PdfDocument(pdfWriter))
            {
                ...
            }
            var renderedBuffer = new byte[output.Position];
            output.Position = 0;
            output.Read(renderedBuffer, 0, renderedBuffer.Length);
            ...
        }
    }
