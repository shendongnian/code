                    // assuming the image is in your Resources
                    var img = Resources.ImageWithTransparentBckgrnd;
                    var g = Graphics.FromImage(img);
                    using (var ms = new MemoryStream())
                    {
                        img.Save(ms, ImageFormat.Png);
                        IntPtr ipHdc = g.GetHdc();
                        Metafile mf = new Metafile(ms, ipHdc);
                        g = Graphics.FromImage(mf);
                        g.FillEllipse(Brushes.White, 0, 0, 16, 16); // size you want to fill in
                        g.Dispose();
                        mf.Save(ms, ImageFormat.Png);
                        IDataObject dataObject = new DataObject();
                        dataObject.SetData("PNG", false, ms);
                        Clipboard.SetDataObject(dataObject, false);
                        richTextBox1.Paste();
                        SendKeys.Send("{RIGHT}");
                        richTextBox1.Focus();
                    }
 
