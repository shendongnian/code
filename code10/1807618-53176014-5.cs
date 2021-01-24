    var imageFiles = Directory.GetFiles(..., "*.jpg");
    var index = -1;
    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
    timer.Tick += (s, e) =>
    {
        if (++index < imageFiles.Length)
        {
            vm.Image = new BitmapImage(new Uri(imageFiles[index]));
        }
        else
        {
            timer.Stop();
        }
    };
    timer.Start();
