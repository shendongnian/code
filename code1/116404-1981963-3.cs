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
                {
                    browser.Width = width;
                    browser.Height = height;
                    browser.ScrollBarsEnabled = true;
                    // This will be called when the page finishes loading
                    browser.DocumentCompleted += Program.OnDocumentCompleted;
                    browser.Navigate("http://stackoverflow.com/");
                    // This prevents the application from exiting until
                    // Application.Exit is called
                    Application.Run();
                }
            }
            static void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                // Now that the page is loaded, save it to a bitmap
                WebBrowser browser = (WebBrowser)sender;
                using (Graphics graphics = browser.CreateGraphics())
                using (Bitmap bitmap = new Bitmap(browser.Width, browser.Height, graphics))
                {
                    Rectangle bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                    browser.DrawToBitmap(bitmap, bounds);
                    bitmap.Save("screenshot.bmp", ImageFormat.Bmp);
                }
                // Instruct the application to exit
                Application.Exit();
            }
        }
    }
