    Uri myUri = new Uri("Images\planBIMGIF.gif", UriKind.RelativeOrAbsolute);
    GifBitmapDecoder decoder = new GifBitmapDecoder(myUri, 		 
    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
	BitmapSource bitmapSource;
	int frameCount = decoder.Frames.Count;
    
	Thread th = new Thread(() =>
	{
	    for (int i = 0; i < frameCount - 1; i++)
		{
			this.Dispatcher.Invoke(new Action(delegate ()
			{
				bitmapSource = decoder.Frames[i];
				image.Source = bitmapSource;
			}));
			System.Threading.Thread.Sleep(50);
		}
	});
	th.Start();
