    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace WpfApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
        public RenderTargetBitmap GetImage(FrameworkElement element)
        {
            Size size = new Size(element.ActualWidth, element.ActualHeight);
            if (size.IsEmpty)
                return null;
            element.Measure(size);
            element.Arrange(new Rect(size));
    
            RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
    
            DrawingVisual drawingvisual = new DrawingVisual();
            using (DrawingContext context = drawingvisual.RenderOpen())
            {
                context.DrawRectangle(new VisualBrush(element), null, new Rect(new Point(), size));
            }
    
            result.Render(drawingvisual);
            return result;
        }
    
            public static void SaveAsPng(RenderTargetBitmap src)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.Filter = "PNG Files | *.png";
                dlg.DefaultExt = "png";
                if (dlg.ShowDialog() == true)
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(src));
                    using (var stream = dlg.OpenFile())
                    {
                        encoder.Save(stream);
                    }
                }
            }
    
            private void Btn_capture_Click(object sender, RoutedEventArgs e)
            {
                SaveAsPng(GetImage(sp_ports));
            }
        }
    }
