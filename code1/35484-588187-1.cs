    public void SetAnimationClip (Bitmap bitmapStrip)
    {
        m_animationIcons = new Icon[bitmapStrip.Width / 16];
        for (int i = 0; i < m_animationIcons.Length; i++)
        {
            Rectangle rect = new Rectangle(i*16, 0, 16, 16);
            Bitmap bmp = bitmapStrip.Clone(rect, bitmapStrip.PixelFormat);
            m_animationIcons[i] = Icon.FromHandle(bmp.GetHicon());
        }
    }
 
