    public Icon AddIconOverlay(Icon originalIcon, Icon overlay)
    {
        Image a = originalIcon.ToBitmap();
        Image b = overlay.ToBitmap();
        Bitmap bitmap = new Bitmap(16, 16);
        Graphics canvas = Graphics.FromImage(bitmap);
        canvas.DrawImage(a, new Point(0, 0));
        canvas.DrawImage(b, new Point(0, 0));
        canvas.Save();
        return Icon.FromHandle(bitmap.GetHicon());
    }
