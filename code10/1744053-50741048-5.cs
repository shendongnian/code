        private static void UpdateExtent(dynamic inlineElement)
        {
            // Read Default Cx and Cy Values provided in Emu
            var extentCx = inlineElement.Cx;
            var extentCy = inlineElement.Cy;
            // Aspect ratio used to set image height after calculation of width
            double aspectRatioOfImage = (double)extentCy / extentCx;
            // We know 15 width of Page = 1 width of image in pixel = 9525 EMUs per pixel, and we convert document size to pixel and then to EMU
            // For Default Values Available page width = 15000 page width = 15000/ 15 pixels = 1000 pixels = 1000 * 9525 Emu = 9525000 Emu
            double newExtentCx = EmuPerPixel * ((PageWidth - PageMarginLeft - PageMarginRight) / DocumentSizePerPixel);
            // Maintain the Aspect Ratio for height
            double newExtentCy = aspectRatioOfImage * newExtentCx;
            // Update the values
            inlineElement.Cx = (long)Math.Round(newExtentCx);
            inlineElement.Cy = (long)Math.Round(newExtentCy);
        } 
