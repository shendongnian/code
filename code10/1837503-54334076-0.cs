    [assembly: ExportRenderer(typeof(Forms.TestPage), typeof(.iOS.Renderers.TestPage))]
    namespace Mindflow.Gamification.Mercedes.iOS.Renderers
    {
        public class TestPage : PageRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement != null || Element == null)
                {
                    return;
                }
    
    
                var page = e.NewElement as Mindflow.Gamification.Forms.Pages.Game.GamePage;
    
                UIGraphics.BeginImageContext(View.Frame.Size);
                UIImage i = UIImage.FromFile(page.BackgroundImage);
                i = i.Scale(View.Frame.Size);
    
                View.BackgroundColor = UIColor.FromPatternImage(i);
            }
        }
    }
