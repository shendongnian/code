    using System;
    using System.Web;
    using System.Threading;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Controls;
    using System.Windows.Documents;
    public partial class _Default : System.Web.UI.Page
    {
        private byte[] imageBuffer;
        public void Page_Load(object sender, EventArgs e)
        {
            this.RenderImage();
            Response.Clear();
            Response.ContentType = @"image/png";
            Response.BufferOutput = true;
            Response.BinaryWrite(this.imageBuffer);
            Response.Flush();
        }
        public void RenderImage()
        {
            Thread worker = new Thread(new ThreadStart(this.RenderImageWorker));
            worker.SetApartmentState(ApartmentState.STA);
            worker.Name = "RenderImageWorker";
            worker.Start();
            worker.Join();
        }
        public void RenderImageWorker()
        {
            Canvas imageCanvas = new Canvas { Width = 600, Height = 200, Background = Brushes.Azure };
            TextBlock tb = new TextBlock();
            tb.Width = (double)400;
            //tb.Height = (double)200;
            tb.TextAlignment = TextAlignment.Center;
            tb.Inlines.Add(new Run("This is "));
            tb.Inlines.Add(new Bold(new Run("bold")));
            tb.Inlines.Add(new Run(" text."));
            tb.FontSize = 30;
            tb.Foreground = Brushes.Blue;
            imageCanvas.Children.Add(tb);
            // Update layout from new controls
            imageCanvas.UpdateLayout();
            imageCanvas.Measure(new Size((int)imageCanvas.Width, (int)imageCanvas.Height));
            imageCanvas.Arrange(new Rect(new Size((int)imageCanvas.Width, (int)imageCanvas.Height)));
            RenderTargetBitmap bitmapRenderer = new RenderTargetBitmap((int)imageCanvas.ActualWidth, (int)imageCanvas.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmapRenderer.Render(imageCanvas);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bitmapRenderer));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                png.Save(memoryStream);
                this.imageBuffer = memoryStream.ToArray();
            }
        }
    }
