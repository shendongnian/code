    nextBtn.Click += (obj, Args) =>
    {
      customMediaPlayer.Source=new Uri(CustomMediaSource.ToString(),UriKind.RelativeOrAbsolute);  //No idea what this doing
      OnMovedNext(EventArgs.Empty);
    };
    prevBtn.Click += (obj, Args) =>
    {
      customMediaPlayer.Source = new Uri(CustomMediaSource.ToString(), UriKind.RelativeOrAbsolute); //No idea what this is doing either
      OnMovedPrevious(EventArgs.Empty);
    };
