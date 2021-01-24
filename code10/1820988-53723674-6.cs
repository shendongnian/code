     void FillIndexedRectangle(Bitmap bmp8bpp, Rectangle rect, 
                               Color col, int index, int stroke)
    ...
    ...
    Marshal.Copy(bitmapData.Scan0, buffer,0, buffer.Length);
    Rectangle ri = rect;
    if (stroke > 0) ri.Inflate(-stroke, -stroke);
    for (int y = rect.Y; y < rect.Bottom; y++)
    for (int x = rect.X; x < rect.Right; x++)
    {
            if (ri == rect || !ri.Contains(x,y))
                buffer[x + y * bmp8bpp.Width] = (byte)idx;
    }
    Marshal.Copy(buffer, 0, bitmapData.Scan0,buffer.Length);
  
