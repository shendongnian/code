[assembly: ExportRenderer(typeof(MyPage), typeof(HomeIndicatorRenderer))]
namespace MyApp
{ 
    public class HomeIndicatorRenderer : PageRenderer
    {
        public override bool PrefersHomeIndicatorAutoHidden => true;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            SetNeedsUpdateOfHomeIndicatorAutoHidden();
        }
    }
}
You should probably mix in a check if the version is iOS 11 or higher somewhere.
But as already pointed out, you probably want to be careful with this. And I think the Apple documentation even states that this setting can be ignored by the OS at will.
