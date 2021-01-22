    protected override void LoadContent()
    {
        // Other stuff...
        // The size of the cursor in pixels.
        int cursorSize = 32;
        // Draw the cursor to a Bitmap
        Cursor cursor = Cursors.IBeam;
        Bitmap image = new Bitmap(cursorSize, cursorSize);
        Graphics graphics = Graphics.FromImage(image);
        cursor.Draw(graphics, new Rectangle(0, 0, cursorSize, cursorSize));
        // Extract pixels from the bitmap, and copy into the texture.
        cursorTexture = new Texture2D(GraphicsDevice, cursorSize, cursorSize);
        Microsoft.Xna.Framework.Graphics.Color[] data = new Microsoft.Xna.Framework.Graphics.Color[cursorSize * cursorSize];
        for (int y = 0; y < cursorSize; y++)
        {
            for (int x = 0; x < cursorSize; x++)
            {
                System.Drawing.Color color = image.GetPixel(x, y);
                data[x + y * cursorSize] = new Microsoft.Xna.Framework.Graphics.Color(color.R, color.G, color.B, color.A);
            }
        }
        cursorTexture.SetData<Microsoft.Xna.Framework.Graphics.Color>(data);
    }
