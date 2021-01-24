    public partial class MainWindow : Window
    {
        protected override void OnContentRendered(EventArgs e)
        {
            double width = 800;
            double heigth = 600;
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)width, (int)heigth, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(plotter);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (Stream stm = File.Create(@"c:\MyCustomPath\test.png")) { encoder.Save(stm); }
        }
        public MainWindow()
        {
            InitializeComponent();
            double[] x = new double[200];
            for (int i = 0; i < x.Length; i++)
                x[i] = 3.1415 * i / (x.Length - 1);
            for (int i = 0; i < 25; i++)
            {
                var lg = new LineGraph();
                lines.Children.Add(lg);
                lg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, (byte)(i * 10), 0));
                lg.Description = String.Format("Data series {0}", i + 1);
                lg.StrokeThickness = 2;
                lg.Plot(x, x.Select(v => Math.Sin(v + i / 10.0)).ToArray());
            }
        }
    }
