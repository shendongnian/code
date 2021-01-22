                   BitmapFrame bi = BitmapFrame.Create(new Uri(value.ToString()), BitmapCreateOptions.DelayCreation, BitmapCacheOption.OnDemand);
                // If this is a photo there should be a thumbnail image, this is VERY fast
                if (bi.Thumbnail != null)
                {
                    return bi.Thumbnail;
                }
                else
                {
                    // No thumbnail so make our own (Not so fast)
                    BitmapImage bi2 = new BitmapImage();
                    bi2.BeginInit();
                    bi2.DecodePixelWidth = 100;
                    bi2.CacheOption = BitmapCacheOption.OnLoad;
                    bi2.UriSource = new Uri(value.ToString());
                    bi2.EndInit();
                    return bi2;
                }
