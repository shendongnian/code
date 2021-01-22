    if (style == Style.Fill)
    {
    	key.SetValue(@"WallpaperStyle", 10.ToString());
    	key.SetValue(@"TileWallpaper", 0.ToString());
    }
    if (style == Style.Fit)
    {
    	key.SetValue(@"WallpaperStyle", 6.ToString());
    	key.SetValue(@"TileWallpaper", 0.ToString());
    }
    if (style == Style.Span) // Windows 8 or newer only!
    {
    	key.SetValue(@"WallpaperStyle", 22.ToString());
    	key.SetValue(@"TileWallpaper", 0.ToString());
    }
    if (style == Style.Stretch)
    {
    	key.SetValue(@"WallpaperStyle", 2.ToString());
    	key.SetValue(@"TileWallpaper", 0.ToString());
    }
    if (style == Style.Tile)
    {
    	key.SetValue(@"WallpaperStyle", 0.ToString());
    	key.SetValue(@"TileWallpaper", 1.ToString());
    }
    if (style == Style.Center)
    {
    	key.SetValue(@"WallpaperStyle", 0.ToString());
    	key.SetValue(@"TileWallpaper", 0.ToString());
    }
