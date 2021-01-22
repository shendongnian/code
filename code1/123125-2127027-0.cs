    private void Instance_VideoRefresh()
    {
        if (VideoImageContainer.Instance.VideoImage != null)
            this.VideoCapture.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(
                      delegate()
                      {
                          videoImage.Source = VideoImageContainer.Instance.VideoBitmapSourceImage;
                      }
                  ));
    }
