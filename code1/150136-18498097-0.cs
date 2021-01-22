    /// <summary>
        /// Convert url to bitmap byte array
        /// </summary>
        /// <param name="url">Url to browse</param>
        /// <param name="width">width of page (if page contains frame, you need to pass this params)</param>
        /// <param name="height">heigth of page (if page contains frame, you need to pass this params)</param>
        /// <param name="htmlToManipulate">function to manipulate dom</param>
        /// <param name="timeout">in milliseconds, how long can you wait for page response?</param>
        /// <returns>bitmap byte[]</returns>
        /// <example>
        /// byte[] img = new Uri("http://www.uol.com.br").ToImage();
        /// </example>
        public static byte[] ToImage(this Uri url, int? width = null, int? height = null, Action<HtmlDocument> htmlToManipulate = null, int timeout = -1)
        {
            byte[] toReturn = null;
    
            Task tsk = Task.Factory.StartNew(() =>
            {
                WebBrowser browser = new WebBrowser() { ScrollBarsEnabled = false };
                browser.Navigate(url);
    
                browser.DocumentCompleted += (s, e) =>
                {
                    var browserSender = (WebBrowser)s;
    
                    if (browserSender.ReadyState == WebBrowserReadyState.Complete)
                    {
                        if (htmlToManipulate != null) htmlToManipulate(browserSender.Document);
    
                        browserSender.ClientSize = new Size(width ?? browser.Document.Body.ScrollRectangle.Width, height ?? browser.Document.Body.ScrollRectangle.Bottom);
                        browserSender.ScrollBarsEnabled = false;
                        browserSender.BringToFront();
    
                        using (Bitmap bmp = new Bitmap(browserSender.Document.Body.ScrollRectangle.Width, browserSender.Document.Body.ScrollRectangle.Bottom))
                        {
                            browserSender.DrawToBitmap(bmp, browserSender.Bounds);
                            toReturn = (byte[])new ImageConverter().ConvertTo(bmp, typeof(byte[]));
                        }
                    }
    
                };
    
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
    
                browser.Dispose();
    
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    
            tsk.Wait(timeout);
    
            return toReturn;
        }
