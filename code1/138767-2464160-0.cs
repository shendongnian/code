    private static void PlayLoop(string filename)
    {
        Audio player = new Audio(filename);
        player.Play();
        //System.Timers.Timer (i reduce the length by 100 ms to try to avoid blank)
        var timer = new Timer((player.Duration - TimeSpan.FromMilliseconds(100)).TotalMilliseconds());
        timer.Elapsed += (sender, arg) =>
        {
            player.SeekCurrentPosition(0, SeekPositionFlags.AbsolutePositioning);
        };
        timer.Start();
    }
