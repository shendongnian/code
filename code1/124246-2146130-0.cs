    private Bitmap backgroundBitmap;
    private Graphics backgroundGraphics;
    private Rectangle rect;
    private Rectangle srcRect;
    // create background bitmap the same size as your screen
    backgroundBitmap = new Bitmap(this.Width, this.Height);
    // create background buffer
    backgroundGraphics = Graphics.FromImage(backgroundBitmap);
    // get current screen graphics
    g = this.CreateGraphics();
    rect = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
    srcRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    Then when you receive your event and need to update the screen, call your own method:
    Render();
    private void Render()
        {            
            // draw your image onto the background buffer
            backgroundGraphics.DrawImage(bmp, rect, srcRect, GraphicsUnit.Pixel);
            // draw whatever you need to on the background graphics
	    backgroundGraphics.DrawImage(.....)
           
            // after all images are drawn onto the background surface
            // blit back buffer to on the screen in one go
            g.DrawImage(backgroundBitmap, this.ClientRectangle,
                new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height), GraphicsUnit.Pixel);
            
        }
