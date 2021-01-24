    [assembly: ExportRenderer(typeof(MaterialPage), typeof(MaterialPageRenderer))]
    namespace SpecialPageRenderer.iOS
    {
        public class MaterialPageRenderer : PageRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
                if (Element != null)
                {
                    var materialView = UIStoryboard.FromName("Main", null).InstantiateViewController("ViewController").View;
    
                    NativeView.AddSubview(materialView);
                }
            }
        }   
    }
