    [assembly: ExportRenderer(typeof(CustomPage), typeof(CustomPageRenderer))]
    namespace UIBarButtomItemsForms.iOS
    {
        public class CustomPageRenderer : PageRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
    
            }
    
            public override void ViewWillAppear(bool animated)
            {
                base.ViewWillAppear(animated);
    
                var navigationItem = NavigationController.TopViewController.NavigationItem;
    
                UIBarButtonItem leftItem = new UIBarButtonItem(UIImage.FromBundle("Image.png"), UIBarButtonItemStyle.Plain, (sender, args) =>
                {
    
                });
    
                navigationItem.SetLeftBarButtonItem(leftItem, false);
            }
        }
    }
