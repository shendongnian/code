    Image paintImage;
    private readonly object paintObject = new object();
    public _ctor() { paintImage = new Image(); }
    override OnPaint(PaintEventArgs pea) {
        if (needUpdate) {
            new Thread(updateImage).Start();
        }
        lock(paintObject) {
            pea.DrawImage(image, 0, 0, Width, Height);
        }
    }
    public void updateImage() {
        // don't draw to paintImage directly (it might cause threading issues)
        Image img = new Image();
        using (Graphics g = img.GetGraphics()) {
            foreach (PaintableObject po in renderObjects) {
                g.DrawObject(po);
            }
        }
        lock(paintObject){
            using (Graphics g = paintImage.GetGraphics()) {
                g.DrawImage(img, 0, 0, g.Width, g.Height);
            }
        }
        needUpdate = false;
    }
    
