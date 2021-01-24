    namespace Solutions
    {
        using System;
        using System.Linq;
        using DocumentFormat.OpenXml;
        using DocumentFormat.OpenXml.Drawing;
        using DocumentFormat.OpenXml.Drawing.Wordprocessing;
        using DocumentFormat.OpenXml.Packaging;
        using DocumentFormat.OpenXml.Wordprocessing;
        using HtmlToOpenXml;
    
        using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
    
        class Program
        {
            const string Html = "<p>SomeText<img src=\"data:image/png;base64,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\" alt=\"Screenshot_3\" />moretext</p>";
    
            // Define Constants for Page Width and Page Margin
            private const int PageWidth = 17000;
            private const int PageHeight = 10000;
            private const int PageMarginLeft = 1000;
            private const int PageMarginRight = 1000;
            private const int PageMarginTop = 1000;
            private const int PageMarginBottom = 1000;
            private const double DocumentSizePerPixel = 15;
            private const double EmuPerPixel = 9525;
    
            static void Main()
            {
                string fileName = @"f:\myDoc.docx";
    
                using (WordprocessingDocument document = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
                {
                    document.AddMainDocumentPart();
                    document.MainDocumentPart.Document = new Document(new Body());
    
                    HtmlConverter conveter = new HtmlConverter(document.MainDocumentPart);
                    var compositeElements = conveter.Parse(Html);
                    var p = compositeElements[0] as Paragraph;
    
    
                    // Set Page Size and Page Margin so that we can place the image as desired.
                    // Available Width = PageWidth - PageMarginLeft - PageMarginRight (= 17000 - 1000 - 1000 = 15000 for default values)
                    var sectionProperties = new SectionProperties();
                    sectionProperties.AppendChild(new PageSize { Width = PageWidth, Height = PageHeight });
                    sectionProperties.AppendChild(new PageMargin { Left = PageMarginLeft, Bottom = PageMarginBottom, Top = PageMarginTop, Right = PageMarginRight });
                    document.MainDocumentPart.Document.Body.AppendChild(sectionProperties);
    
                    if (p != null)
                    {
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
                    }
    
                    document.MainDocumentPart.Document.Body.Append(compositeElements);
                }
            }
        }
    }
