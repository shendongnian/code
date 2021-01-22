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
                    browser.DocumentCompleted += (o, e) => completed.Set();
                    browser.Navigate("http://stackoverflow.com/");
                    while (!completed.WaitOne(TimeSpan.FromMilliseconds(100.0d)))
                    {
                        Application.DoEvents();
                    }
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
