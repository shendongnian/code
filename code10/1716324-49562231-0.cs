     MapZoomLevelRange range;
            range.Min = 0;
            range.Max = 5;
             
            LocalMapTileDataSource dataSource = new LocalMapTileDataSource("ms-appx:///Assets/Maps/{zoomlevel}/{x}/{y}.png");
            
            MapTileSource tileSource = new MapTileSource(dataSource);
            tileSource.ZoomLevelRange = range;
            tileSource.Layer = MapTileLayer.BackgroundReplacement;
            TestMap1.Style = MapStyle.None;
            tileSource.IsFadingEnabled = false;
            TestMap1.TileSources.Add(tileSource);
