    namespace WebBrowserScreenshotSample
    {
        using System;
        using System.Drawing;
        using System.Drawing.Imaging;
        using System.Threading;
        using System.Windows.Forms;
        class Program
        {
            [STAThread]
            static void Main()
            {
                int width = 800;
                int height = 600;
                using (WebBrowser browser = new WebBrowser())
                using (ManualResetEvent completed = new ManualResetEvent(false))
                {
                    browser.Width = width;
                    browser.Height = height;
                    browser.ScrollBarsEnabled = true;
                    // We will set the event when the page is finished loading
                    browser.DocumentCompleted += (o, e) => completed.Set();
                    browser.Navigate("http://stackoverflow.com/");
                    // Now we need to wait for the event to be set; this is
                    // tricky because we are basically single threaded so we
                    // can't just block and wait for it to complete. Instead
                    // we will periodically wait and then allow the app to
                    // process other events in the background. This should
                    // ensure that the web page actually finishes loading in
                    // the background.
                    while (!completed.WaitOne(TimeSpan.FromMilliseconds(100.0d)))
                    {
                        Application.DoEvents();
                    }
                    // Now that the page is loaded, we can draw it to a bitmap
                    // and save it in the format of our choice.
                    using (Graphics graphics = browser.CreateGraphics())
                    using (Bitmap bitmap = new Bitmap(width, height, graphics))
                    {
                        Rectangle bounds = new Rectangle(0, 0, width, height);
                        browser.DrawToBitmap(bitmap, bounds);
                        bitmap.Save("screenshot.bmp", ImageFormat.Bmp);
                    }
                }
            }
        }
    }
