    MessagingCenter.Subscribe<App>(this, "OnSleep", (sender) => {
    //shows start button instead of stop button
    if (null != timer)
    {
        StartGrid.IsVisible = true;
        //hides stop button
        StopNextGrid.IsVisible = false;
        //stops timer
        timer.Stop();
        timer = null;
        //stops sound
        startSound.Stop();
        stopSound.Play();
    }
    });
