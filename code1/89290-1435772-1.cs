    if (e.ColumnIndex == 3) //last column index
    {
      ListView lv = e.Header.ListView;
      IntPtr headerControl = NativeMethods.GetHeaderControl(lv);
      IntPtr hdc = GetDC(headerControl);
      Graphics g = Graphics.FromHdc(hdc);
    
      // Do your extra drawing here
      Rectangle rc = new Rectangle(e.Bounds.Right, //Right instead of Left - offsets the rectangle
                e.Bounds.Top, 
                e.Bounds.Width, 
                e.Bounds.Height);
    
        e.Graphics.FillRectangle(Brushes.Red, rc);
    
      g.Dispose();
      ReleaseDC(headerControl, hdc);
    }
