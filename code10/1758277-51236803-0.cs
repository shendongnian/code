    private Image combineFrames(Image[] images, int columns) {
        int rows = (int) Math.Ceiling((double) images.Length / columns);
    
        using (Bitmap bitmap = new Bitmap(images[0].Width * columns, images[0].Height * rows) {
            using (Graphics graphics = Graphics.FromImage(bitmap)) {
                for (int i = 0; i < images.Length; ++i) {
                    Image image = images[i];
    
                    graphics.DrawImage(
                        image,
                        image.Width * (i % columns),
                        image.Height * (int) ((double) i / columns)
                    ); 
                }
            }
        }
    }
