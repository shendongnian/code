    namespace WebBrowserScreenshotFormsSample
    {
        using System;
        using System.Drawing;
        using System.Drawing.Imaging;
        using System.IO;
        using System.Windows.Forms;
        public partial class MainForm : Form
        {
            public MainForm()
            {
                this.InitializeComponent();
                // Register for this event; we'll save the screenshot when it fires
                this.webBrowser.DocumentCompleted += 
                    new WebBrowserDocumentCompletedEventHandler(this.OnDocumentCompleted);
            }
            private void OnClickGenerateScreenshot(object sender, EventArgs e)
            {
                // Disable button to prevent multiple concurrent operations
                this.generateScreenshotButton.Enabled = false;
                string webAddressString = this.webAddressTextBox.Text;
                Uri webAddress;
                if (Uri.TryCreate(webAddressString, UriKind.Absolute, out webAddress))
                {
                    this.webBrowser.Navigate(webAddress);
                }
                else
                {
                    MessageBox.Show(
                        "Please enter a valid URI.",
                        "WebBrowser Screenshot Forms Sample",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    // Re-enable button on error before returning
                    this.generateScreenshotButton.Enabled = true;
                }
            }
            private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                // This event can be raised multiple times depending on how much of the
                // document has loaded, if there are multiple frames, etc.
                // We only want the final page result, so we do the following check:
                if (this.webBrowser.ReadyState == WebBrowserReadyState.Complete &&
                    e.Url == this.webBrowser.Url)
                {
                    // Generate the file name here
                    string screenshotFileName = Path.GetFullPath(
                        "screenshot_" + DateTime.Now.Ticks + ".png");
                    this.SaveScreenshot(screenshotFileName);
                    MessageBox.Show(
                        "Screenshot saved to '" + screenshotFileName + "'.",
                        "WebBrowser Screenshot Forms Sample",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    // Re-enable button before returning
                    this.generateScreenshotButton.Enabled = true;
                }
            }
            private void SaveScreenshot(string fileName)
            {
                int width = this.webBrowser.Width;
                int height = this.webBrowser.Height;
                using (Graphics graphics = this.webBrowser.CreateGraphics())
                using (Bitmap bitmap = new Bitmap(width, height, graphics))
                {
                    Rectangle bounds = new Rectangle(0, 0, width, height);
                    this.webBrowser.DrawToBitmap(bitmap, bounds);
                    bitmap.Save(fileName, ImageFormat.Png);
                }
            }
        }
    }
