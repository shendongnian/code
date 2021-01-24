        public static ImageDataModel Combine(List<ImageDataModel> inputImages)
        {
            //  Right ascension is CRVAL1
            //  Declination is CRVAL2
            //  formula is (since distance is the same for everything):
            //     x = cos(dec) * cos(ra)
            //     y = cos(dec) * sin(ra)
            ImageDataModel returnImage = new ImageDataModel();
            ImageDataModel bm = inputImages[0];
            double x1, y1, x2, y2;
            x1 = Math.Cos(bm.CRVAL2) * Math.Cos(bm.CRVAL1);
            y1 = Math.Cos(bm.CRVAL2) * Math.Sin(bm.CRVAL1);
            var values = Rotate(0 - bm.Orientation, x1, y1);
            x1 = values.x;
            y1 = values.y;
            int mult = 4; // todo: set this based off of the bitpix of the incoming images.
            for (int i = 1; i < inputImages.Count; i++)
            {
                ImageDataModel cm = inputImages[i];
                x2 = Math.Cos(cm.CRVAL2) * Math.Cos(cm.CRVAL1);
                y2 = Math.Cos(cm.CRVAL2) * Math.Sin(cm.CRVAL1);
                var values2 = Rotate(0 - bm.Orientation, x2, y2);
                x2 = values2.x;
                y2 = values2.y;
                double dx = x1 - x2;
                double dy = y1 - y2;
                int distX = (int)((dx * 3600) / PixelsPerArcSecond);
                int distY = (int)((dy * 3600) / PixelsPerArcSecond);
                double width = (1.0 + x1) * (bm.ImageWidth / 2) + (1.0 - x2) * (cm.ImageWidth / 2) + Math.Abs(distX);
                double height = (1.0 + y1) * (bm.ImageHeight / 2) + (1.0 - y2) * (cm.ImageHeight / 2) + Math.Abs(distY);
                // This is what I expect to be wider than tall, but the converse is true.
                int w = Math.Abs(distX) + (bm.ImageWidth / 2) + (cm.ImageWidth / 2);
                int h = Math.Abs(distY) + (bm.ImageHeight / 2) + (cm.ImageHeight / 2);
                // This is where the two images are combined into the final image.
                ImageDataModel imd = CombineTwoImages(bm, cm, i, w, h, mult);
                bm = imd;
            }
            return returnImage;
        }
        private static (double x, double y) Rotate(int angle, double x, double y)
        {
            double rad = Math.PI * angle / 180.0;
            return (x * Math.Cos(rad) - y * Math.Sin(rad), x * Math.Sin(rad) + y * Math.Cos(rad));
        }
