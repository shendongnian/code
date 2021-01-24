                     // Search for Extents used by the word present in Drawing > Inline > Extent
                    var inlineEnumerable = p.ChildElements.Where(e => e is DocumentFormat.OpenXml.Wordprocessing.Run)
                        .Where(r => r.GetFirstChild<Drawing>() != null).Select(r => r.GetFirstChild<Drawing>())
                        .Where(r => r.GetFirstChild<Inline>() != null).Select(r => r.GetFirstChild<Inline>());
                    // Update Visible Extent
                    var inlineChildren = inlineEnumerable as Inline[] ?? inlineEnumerable.ToArray();
                    foreach (var inlineChild in inlineChildren)
                    {
                        var inlineElement = inlineChild.Extent;
                        UpdateExtent(inlineElement);
                    }
                    // Search for Extents used by the word present in Drawing > Inline > Graphic > GraphicData > Picture > ShapeProperties > Transform2D > Extents
                    var extentsEnumerable = inlineChildren
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
                        UpdateExtent(inlineElement);
                    }
