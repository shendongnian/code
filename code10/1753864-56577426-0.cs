    using PdfSharp.Pdf;
    using PdfSharp.Pdf.Advanced;
    ...
    // get palette if required (pf is the pixel format, previously extracted from the imageDictionary, imageDictionary is the PdfDictionary for the image, bmp is the System.Drawing.Bitmap we're going to be dumping our image data to)
    if (pf == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
    {
        PdfArray colArr = imageDictionary.Elements.GetArray(PdfImage.Keys.ColorSpace);
        if (colArr != null && colArr.Elements.GetName(0) == "/Indexed" && colArr.Elements.GetName(1) == "/DeviceRGB")
        {
            System.Drawing.Imaging.ColorPalette pal = bmp.Palette;      // this returns a clone, so we'll manipulate it and then set it back at the end
            int palCount = colArr.Elements.GetInteger(2);
            char[] palVal = colArr.Elements.GetString(3).ToCharArray();
            int basePointer = 0;
            for (int i = 0; i < palCount; i++)
            {
                pal.Entries[i] = System.Drawing.Color.FromArgb(palVal[basePointer], palVal[basePointer + 1], palVal[basePointer + 2]);
                basePointer += 3;
            }
            bmp.Palette = pal;
        }
        else
        {
            // some other colorspace mechanism needs to be implemented
        }
    }
