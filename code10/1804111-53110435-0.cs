    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool CloseClipboard();
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern IntPtr GetClipboardData(uint format);
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool IsClipboardFormatAvailable(uint format);
    private Image GetMetaImageFromClipboard()
    {
      try
      {
        Bitmap image;
        Metafile emf = null;
        if (OpenClipboard(IntPtr.Zero))
        {
          if (IsClipboardFormatAvailable(CF_ENHMETAFILE))
          {
            var ptr = GetClipboardData(CF_ENHMETAFILE);
            if (!ptr.Equals(IntPtr.Zero))
              emf = new Metafile(ptr, true);
          }
          CloseClipboard();
        }
        image = new Bitmap(emf.Width, emf.Height, PixelFormat.Format32bppPArgb);
        Graphics g = Graphics.FromImage(image);
        g.DrawImage(emf, 0, 0, image.Width, image.Height);
        g.Dispose();
        emf.Dispose();
        return image;
      }
      catch (Exception ex)
      {
        // some logs
        return null;
      }
      finally
      {
        CloseClipboard();
      }
    }
