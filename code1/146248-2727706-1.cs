    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    
    using AForge;
    using AForge.Imaging;
    using AForge.Imaging.Filters;
    using AForge.Imaging.Textures;
    using AForge.Math.Geometry;
    
    namespace CDIO.Library
    {
        public class MapFilters
        {
            private Bitmap image;
            private Bitmap processedImage;
            private Rectangle[] rectangels;
    
            public void initialize(Bitmap image)
            {
                this.image = image;
            }
    
            public void process()
            {
                processedImage = image;
                processedImage = applyFilters(processedImage);
                processedImage = filterWhite(processedImage);
            }
    
            public Bitmap getProcessedImage
            {
                get
                {
                    return processedImage;
                }
            }
    
            private Bitmap applyFilters(Bitmap image)
            {
                image = new ContrastCorrection(2).Apply(image);
                image = new GaussianBlur(10, 10).Apply(image);
                return image;
            }
    
            private Bitmap filterWhite(Bitmap image)
            {
                Bitmap test = new Bitmap(image.Width, image.Height);
    
                for (int width = 0; width < image.Width; width++)
                {
                    for (int height = 0; height < image.Height; height++)
                    {
                        if (image.GetPixel(width, height).R > 200 &&
                            image.GetPixel(width, height).G > 200 &&
                            image.GetPixel(width, height).B > 200)
                        {
                            test.SetPixel(width, height, Color.White);
                        }
                        else
                            test.SetPixel(width, height, Color.Black);
                    }
                }
                return test;
            }
        }
    }
