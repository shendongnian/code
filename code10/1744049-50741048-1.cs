                // Search for Extents used by the word present in Drawing > Inine > Graphic > GraphicData > Picture > ShapeProperties > Transform2D > Extents
                var extentsEnumerable = p.ChildElements.Where(e => e is DocumentFormat.OpenXml.Wordprocessing.Run)
                    .Where(r => r.GetFirstChild<Drawing>() != null).Select(r => r.GetFirstChild<Drawing>())
                    .Where(r => r.GetFirstChild<Inline>() != null).Select(r => r.GetFirstChild<Inline>())
                    .Where(r => r.GetFirstChild<Graphic>() != null).Select(d => d.GetFirstChild<Graphic>())
                    .Where(r => r.GetFirstChild<GraphicData>() != null).Select(r => r.GetFirstChild<GraphicData>())
                    .Where(r => r.GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.Picture>() != null)
                    .Select(r => r.GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.Picture>())
                    .Where(r => r.GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties>() != null)
                    .Select(r => r.GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties>())
                    .Where(r => r.GetFirstChild<Transform2D>() != null).Select(r => r.GetFirstChild<Transform2D>())
                    .Where(r => r.GetFirstChild<Extents>() != null).Select(r => r.GetFirstChild<Extents>());
                // Modify all images in Extents to the desired size here, to be stretched out on available page width
                foreach (var extents in extentsEnumerable)
                {
                    // Set Image Size: We calculate Aspect Ratio of the image and then calculate the width and update the height as per aspect ratio
                    var inlineElement = extents;
                    // Read Default Cx and Cy Values provided in Emu
                    var extentCx = inlineElement.Cx;
                    var extentCy = inlineElement.Cy;
                    // Aspect ratio used to set image height after calculation of width
                    double aspectRatioOfImage = (double)extentCy / extentCx;
                    // We know 15 width of Page = 1 width of image in pixel = 9525 EMUs per pixel, and we convert document size to pixel and then to EMU
                    // For Default Values Avalable page width = 15000 page width = 15000/ 15 pixels = 1000 pixels = 1000 * 9525 Emu = 9525000 Emu
                    double newExtentCx = EmuPerPixel * ((PageWidth - PageMarginLeft - PageMarginRight) / DocumentSizePerPixel);
                    // Maintain the Aspect Ratio for height
                    double newExtentCy = aspectRatioOfImage * newExtentCx;
                    // Update the values
                    inlineElement.Cx = (long)Math.Round(newExtentCx);
                    inlineElement.Cy = (long)Math.Round(newExtentCy);
                }
    
