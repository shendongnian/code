    [assembly: ExportRenderer(typeof(MyScrollView), typeof(MyScrollRenderer))]
    namespace ExpandLayoutDemo.iOS
    {
        public class MyScrollRenderer : ScrollViewRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
                ScrollEnabled = false;
            }
        }
    }
