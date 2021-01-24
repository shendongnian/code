    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    
    using Xamarin.Forms;
    
    namespace Test2 {
      public partial class MainPage : ContentPage {
        public static readonly SKCanvasView canvasView = new SKCanvasView();
        public MainPage() {
          InitializeComponent();
          canvasView.PaintSurface += OnCanvasViewPaintSurface;
          Content = canvasView;
        }
    
        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e) {
          var surface = e.Surface;
          var canvas = surface.Canvas;
          var width = e.Info.Width;
          var height = e.Info.Height;
          var x = width/2.0f;
          var y = height/2.0f;
          var paint = new SKPaint();
          paint.TextSize = 14.0f;
          paint.IsAntialias = true;
          paint.Color = SKColors.Red;
          paint.IsStroke = false;
          var textBounds = new SKRect();
          var text = "Welcome to SkiaSharp";
          paint.MeasureText(text, ref textBounds);
          var textWidth = textBounds.Width + 4.0f;
          var textHeight = textBounds.Height + 2.0f;
          x -= textWidth/2.0f;
    
          canvas.DrawText(text, x, y, paint);
        }
      }
    }
