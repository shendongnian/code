    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    namespace Ink
    {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public InkPresenter ink = new InkPresenter();
        public Window1()
        {
            InitializeComponent();
            StylusPoint segment1Start = new StylusPoint(200, 110);
            StylusPoint segment1End = new StylusPoint(185, 150);
            StylusPoint segment2Start = new StylusPoint(185, 150);
            StylusPoint segment2End = new StylusPoint(135, 150);
            StylusPoint segment3Start = new StylusPoint(135, 150);
            StylusPoint segment3End = new StylusPoint(175, 180);
            StylusPoint segment4Start = new StylusPoint(175, 180);
            StylusPoint segment4End = new StylusPoint(160, 220);
            StylusPoint segment5Start = new StylusPoint(160, 220);
            StylusPoint segment5End = new StylusPoint(200, 195);
            StylusPoint segment6Start = new StylusPoint(200, 195);
            StylusPoint segment6End = new StylusPoint(240, 220);
            StylusPoint segment7Start = new StylusPoint(240, 220);
            StylusPoint segment7End = new StylusPoint(225, 180);
            StylusPoint segment8Start = new StylusPoint(225, 180);
            StylusPoint segment8End = new StylusPoint(265, 150);
            StylusPoint segment9Start = new StylusPoint(265, 150);
            StylusPoint segment9End = new StylusPoint(215, 150);
            StylusPoint segment10Start = new StylusPoint(215, 150);
            StylusPoint segment10End = new StylusPoint(200, 110);
            StylusPointCollection strokePoints = new StylusPointCollection();
            strokePoints.Add(segment1Start);
            strokePoints.Add(segment1End);
            strokePoints.Add(segment2Start);
            strokePoints.Add(segment2End);
            strokePoints.Add(segment3Start);
            strokePoints.Add(segment3End);
            strokePoints.Add(segment4Start);
            strokePoints.Add(segment4End);
            strokePoints.Add(segment5Start);
            strokePoints.Add(segment5End);
            strokePoints.Add(segment6Start);
            strokePoints.Add(segment6End);
            strokePoints.Add(segment7Start);
            strokePoints.Add(segment7End);
            strokePoints.Add(segment8Start);
            strokePoints.Add(segment8End);
            strokePoints.Add(segment9Start);
            strokePoints.Add(segment9End);
            strokePoints.Add(segment10Start);
            strokePoints.Add(segment10End);
            Stroke newStroke = new Stroke(strokePoints);
            ink.Strokes.Add(newStroke);
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => 
            {
                saveInkPresenter();
            }
            ));
        }
        public void saveInkPresenter()
        {
            Rect rect = new Rect(0, 0, 300, 300);
            RenderTargetBitmap targetBitmap = new RenderTargetBitmap((int)rect.Right, (int)rect.Bottom, 96d, 96d, PixelFormats.Default);
            ink.Measure(new Size((int)rect.Right, (int)rect.Bottom));
            ink.Arrange(new Rect(new Size((int)rect.Right, (int)rect.Bottom)));
            targetBitmap.Render(ink);
            targetBitmap.Freeze();
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(targetBitmap));
            using (Stream stm = File.Create("test.png"))
            {
                png.Save(stm);
            }
        }
    }
     }
