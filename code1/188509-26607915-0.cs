    iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
    iTextSharp.text.pdf.PdfImportedPage page;
    int rotation;
    int i = 0;
    while (i < pageCount)
    {
        i++;
        var pageSize = reader.GetPageSizeWithRotation(i);
        // Pull in the page from the reader
        page = writer.GetImportedPage(reader, i);
        // Get current page rotation in degrees
        rotation = pageSize.Rotation;
        // Default to the current page size
        iTextSharp.text.Rectangle newPageSize = null;
        // Apply our additional requested rotation (switch height and width as required)
        switch (rotateFlipType)
        {
            case RotateFlipType.RotateNoneFlipNone:
                newPageSize = new iTextSharp.text.Rectangle(pageSize);
                break;
            case RotateFlipType.Rotate90FlipNone:
                rotation += 90;
                newPageSize = new iTextSharp.text.Rectangle(pageSize.Height, pageSize.Width, rotation);
                break;
            case RotateFlipType.Rotate180FlipNone:
                rotation += 180;
                newPageSize = new iTextSharp.text.Rectangle(pageSize.Width, pageSize.Height, rotation);
                break;
            case RotateFlipType.Rotate270FlipNone:
                rotation += 270;
                newPageSize = new iTextSharp.text.Rectangle(pageSize.Height, pageSize.Width, rotation);
                break;
        }
        // Cap rotation into the 0-359 range for subsequent check
        rotation %= 360;
        document.SetPageSize(newPageSize);
        document.NewPage();
        // based on the rotation write out the page dimensions
        switch (rotation)
        {
            case 0:
                cb.AddTemplate(page, 0, 0);
                break;
            case 90:
                cb.AddTemplate(page, 0, -1f, 1f, 0, 0, newPageSize.Height);
                break;
            case 180:
                cb.AddTemplate(page, -1f, 0, 0, -1f, newPageSize.Width, newPageSize.Height);
                break;
            case 270:
                cb.AddTemplate(page, 0, 1f, -1f, 0, newPageSize.Width, 0);
                break;
            default:
                throw new System.Exception(string.Format("Unexpected rotation of {0} degrees", rotation));
                break;
        }
    }
 
