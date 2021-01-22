           ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f);
                // find all matchings with specified above similarity
                TemplateMatch[] matchings = tm.ProcessImage(sourceImage, template);
                // highlight found matchings
           
           BitmapData data = sourceImage.LockBits(
                new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                ImageLockMode.ReadWrite, sourceImage.PixelFormat);
            foreach (TemplateMatch m in matchings)
            {
                
                    Drawing.Rectangle(data, m.Rectangle, Color.White);
                
                MessageBox.Show(m.Rectangle.Location.ToString());
                // do something else with matching
            }
            sourceImage.UnlockBits(data);
