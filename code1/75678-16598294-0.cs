            System.Windows.Media.Imaging.GifBitmapEncoder gEnc = new GifBitmapEncoder();
            
            foreach (Background b in Enum.GetValues(typeof(Background)))
                foreach (Style s in Enum.GetValues(typeof(Style)))
                {
                    var bmpImage = Treadplate.ShowPreview(b, text, s);
                    var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        bmpImage.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                    gEnc.Frames.Add(BitmapFrame.Create(src));
                }
            gEnc.Save(new FileStream(path, FileMode.Create));
