    var backgroundThreadImage = GenerateImage(coordinate);
    GeneratedImage.Dispatcher.Invoke(
            DispatcherPriority.Normal,
            new Action(() =>
                {
                    GeneratedImage = backgroundThreadImage;
                }));
