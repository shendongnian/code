    using (ImageAttributes wrapMode = new ImageAttributes())
    {
    	wrapMode.SetWrapMode(WrapMode.TileFlipXY);
    	g.DrawImage(input, rect, 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, wrapMode);
    }
