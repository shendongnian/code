    public IEnumerable<BitmapImage> BitmapImages { get; private set }
    private void PreloadImages(IEnumerbale<Uri> uriCollection)
    {
        var bitmapImages= new List<BitmapImage>();
    
        uriCollection.ToObservable()
            .SelectMany(LoadImageAsync)
            .Catch(Observable.Empty<BitmapImage>())
            .Subscribe(bitmapImages.Add, 
            () =>
            {
                BitmapImages = bitmapImages;
            });
    }
    
    private IObservable<BitmapImage> LoadImageAsync(Uri uri)
    {
        return Observable.CreateWithDisposable<BitmapImage>(observer =>
        {
            var downloader = new WebClient();
            downloader.OpenReadCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    observer.OnError(e.Error);
                }
    
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = e.Result;
                bitmapImage.EndInit();
                        
                observer.OnNext(bitmapImage);
                observer.OnCompleted();
            };
            downloader.OpenReadAsync(uri);
    
            return downloader;
        });
    }
