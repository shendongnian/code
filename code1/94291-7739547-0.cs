    using System;
    using System.IO;
    using System.Web.Mvc;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    namespace MyMvcWebApp.Controllers
    {
        public class ImageGenController : Controller
        {
            // GET: ~/ImageGen/Gradient?color1=red&color2=pink
            [OutputCache(CacheProfile = "Image")]
            public ActionResult Gradient(Color color1, Color color2, int width = 1, int height = 30, double angle = 90)
            {
                var visual = new DrawingVisual();
                using (DrawingContext dc = visual.RenderOpen())
                {
                    Brush brush = new LinearGradientBrush(color1, color2, angle);
                    dc.DrawRectangle(brush, null, new Rect(0, 0, width, height));
                }
                return new FileStreamResult(renderPng(visual, width, height), "image/png");
            }
            static Stream renderPng(Visual visual, int width, int height)
            {
                var rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
                rtb.Render(visual);
                var frame = BitmapFrame.Create(rtb);
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(frame);
                var stream = new MemoryStream();
                encoder.Save(stream);
                stream.Position = 0;
                return stream;
            }
        }
    }
