    MediaPlayer player = new MediaPlayer();
    player.Open(new Uri(_inputFilename));
    player.ScrubbingEnabled = true;
    DrawingVisual dv = new DrawingVisual();
    for (int i = 0; i < session.FramesList.Count; i++)
    {
        Frame f = session.FramesList[i];
        player.Position = new TimeSpan((long)(f.Time * 10000000));
        using (DrawingContext dc = dv.RenderOpen())
        {
            dc.DrawVideo(player, new Rect(0, 0, 1024, 576));
        }
        RenderTargetBitmap bmp = new RenderTargetBitmap(1024, 576, 96, 96, PixelFormats.Pbgra32);
        bmp.Render(dv);
        f.Thumbnail = bmp.GetAsFrozen() as ImageSource;
        framesListView.Dispatcher.Invoke(() => FramesList.Add(f));
    }
