     public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            if (ViewGroup != null && ViewGroup.ChildCount > 0)
            {
                BottomNavigationView bottomNavigationView = FindChildOfType<BottomNavigationView>(ViewGroup);
                if (bottomNavigationView != null)
                {
                    // use extension method from XF
                    bottomNavigationView.SetShiftMode(false, false);
                }
            }
        }
        private T FindChildOfType<T>(ViewGroup viewGroup) where T : Android.Views.View
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
        protected override void DispatchDraw(Canvas canvas)
        {
            base.DispatchDraw(canvas);
        }
    }
