    Image image;
    protected override OnPaint(...) {
        if (image == null || needRepaint) {
            image = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(image)) {
                // do any painting in image instead of control
            }
            needRepaint = false;
        }
        e.Graphics.DrawImage(image, 0, 0);
    }
