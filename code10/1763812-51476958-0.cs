                                 BitmapImage _image = new BitmapImage();
                                _image.BeginInit();
                                _image.CacheOption = BitmapCacheOption.None;
                                _image.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                                _image.CacheOption = BitmapCacheOption.OnLoad;
                                _image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                                _image.UriSource = new Uri(imageSource, UriKind.RelativeOrAbsolute);
                                _image.EndInit();
                                ImageName.Source = _image;
