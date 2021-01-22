    private void SetBitmapResourcesTransparent()
        {
            Image img;
            BitmapSource bmpSource;
            System.Drawing.Bitmap bmp;
            foreach (ResourceDictionary resdict in Application.Current.Resources.MergedDictionaries)
            {
                foreach (DictionaryEntry dictEntry in resdict)
                {
                    // search for bitmap resource
                    if ((img = dictEntry.Value as Image) is Image 
                        && (bmpSource = img.Source as BitmapSource) is BitmapSource
                        && (bmp = BitmapFromSource(bmpSource)) != null)
                    {
                        // make bitmap transparent and assign it back to ressource
                        bmp.MakeTransparent(System.Drawing.Color.Magenta);
                        bmpSource = ConvertBitmap(bmp);
                        img.Source = bmpSource;
                    }
                }
                
            }
        }
