        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Media;
        namespace WpfApplication1
        {
            public class ImageCanvas : Canvas
            {
                public ImageSource CanvasImageSource
                {
                    get { return (ImageSource)GetValue(CanvasImageSourceProperty); }
                    set { SetValue(CanvasImageSourceProperty, value); }
                }
                public static readonly DependencyProperty CanvasImageSourceProperty =
                    DependencyProperty.Register("CanvasImageSource", typeof(ImageSource),
                    typeof(ImageCanvas), new FrameworkPropertyMetadata(default(ImageSource)));
                protected override void OnRender(System.Windows.Media.DrawingContext dc)
                {
                    dc.DrawImage(CanvasImageSource, new Rect(this.RenderSize));
                    base.OnRender(dc);
                }
            }
        }
