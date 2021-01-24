        /// <param name="text">one or more characters to scale to fill as much of the target image size as required.</param>
        /// <param name="targetSize">the size in pixels to generate the image</param>
        /// <param name="outputFileName">path/filename where to save the image to</param>
        private static void GenerateImage(string text, Primitives.Size targetSize, string outputFileName)
        {
            FontFamily fam = SystemFonts.Find("Arial");
            Font font = new Font(fam, 100); // size doesn't matter too much as we will be scaling shortly anyway
            RendererOptions style = new RendererOptions(font, 72); // again dpi doesn't overlay matter as this code genreates a vector
            // this is the important line, where we render the glyphs to a vector instead of directly to the image
            // this allows further vector manipulation (scaling, translating) etc without the expensive pixel operations.
            IPathCollection glyphs = SixLabors.Shapes.TextBuilder.GenerateGlyphs(text, style);
            var widthScale = (targetSize.Width / glyphs.Bounds.Width);
            var heightScale = (targetSize.Height / glyphs.Bounds.Height);
            var minScale = Math.Min(widthScale, heightScale);
            // scale so that it will fit exactly in image shape once rendered
            glyphs = glyphs.Scale(minScale);
            // move the vectorised glyph so that it touchs top and left edges 
            // could be tweeked to center horizontaly & vertically here
            glyphs = glyphs.Translate(-glyphs.Bounds.Location);
            using (Image<Rgba32> img = new Image<Rgba32>(targetSize.Width, targetSize.Height))
            {
                img.Mutate(i => i.Fill(new GraphicsOptions(true), Rgba32.Black, glyphs));
                img.Save(outputFileName);
            }
        }
