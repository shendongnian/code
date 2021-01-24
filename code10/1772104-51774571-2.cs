    public async void AddTextAsynchronously()
    {            
        progressBarAddingText.IsEnabled = true;
        var stringBuilder = new StringBuilder();
        await Task.Run(() =>
        {
            for (int i = 0; i < 5000; i++)
                stringBuilder.Append("X");
        });
        stopwatch.Start();
        textBlockAddingTextTime.Text = $"{stopwatch.ElapsedMilliseconds.ToString()} milliseconds";
        stopwatch.Stop();
        textBoxAddingText.Text = stringBuilder.ToString();
        progressBarAddingText.IsEnabled = false;
    }
