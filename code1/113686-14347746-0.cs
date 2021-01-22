        public static Image resizeImage(Image imgToResize, Size size)
        {
           return (Image)(new Bitmap(imgToResize, size));
        }
        yourImage = resizeImage(yourImage, new Size(50,50));
