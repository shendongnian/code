using static Xamarin.Forms.Platform.Android.BottomNavigationViewUtils;
public class BottomTabPageRenderer : TabbedPageRenderer
{
    public BottomTabPageRenderer(Context context) : base(context) { }
    protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
    {
        base.OnElementChanged(e);
        if (ViewGroup != null && ViewGroup.ChildCount > 0)
        {
            BottomNavigationMenuView bottomNavigationMenuView = FindChildOfType<BottomNavigationMenuView>(ViewGroup);
            if (bottomNavigationMenuView != null)
            {
                // use extension method from XF
                bottomNavigationMenuView.SetShiftMode(false, false);
            }
        }
        T FindChildOfType<T>(ViewGroup viewGroup) where T : Android.Views.View
        {
            if (viewGroup == null || viewGroup.ChildCount == 0) return null;
            for (var i = 0; i < viewGroup.ChildCount; i++)
            {
                var child = viewGroup.GetChildAt(i);
                var typedChild = child as T;
                if (typedChild != null) return typedChild;
                if (!(child is ViewGroup)) continue;
                var result = FindChildOfType<T>(child as ViewGroup);
                if (result != null) return result;
            }
            return null;
        }
   }
}
