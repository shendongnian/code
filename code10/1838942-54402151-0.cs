      [assembly: ExportRenderer(typeof(TabbedPage), typeof(BottomTabbedPageRenderer))]
    namespace Droid.Renderer
    {
        public class BottomTabbedPageRenderer : TabbedPageRenderer
        {
        public BottomTabbedPageRenderer(Context context) : base(context)
        {
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            try
            {
                var children = GetAllChildViews(ViewGroup);
                if (children.SingleOrDefault(x => x is BottomNavigationView) is BottomNavigationView bottomNav)
                {
                    try
                    {
                        if (!(bottomNav.GetChildAt(0) is BottomNavigationMenuView menuView))
                        {
                            System.Diagnostics.Debug.WriteLine("Unable to find BottomNavigationMenuView");
                            return;
                        }
                        var shiftMode = menuView.Class.GetDeclaredField("mShiftingMode");
                        shiftMode.Accessible = true;
                        shiftMode.SetBoolean(menuView, false);
                        shiftMode.Accessible = false;
                        shiftMode.Dispose();
                        for (int i = 0; i < menuView.ChildCount; i++)
                        {
                            if (!(menuView.GetChildAt(i) is BottomNavigationItemView item))
                                continue;
                            item.SetShiftingMode(false);
                            item.SetChecked(item.ItemData.IsChecked);
                        }
                        menuView.UpdateMenuView();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Unable to set shift mode: {ex}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error setting ShiftMode: {e}");
            }
        }
        private List<View> GetAllChildViews(View view)
        {
            if (!(view is ViewGroup group))
            {
                return new List<View> { view };
            }
            var result = new List<View>();
            for (int i = 0; i < group.ChildCount; i++)
            {
                var child = group.GetChildAt(i);
                var childList = new List<View> { child };
                childList.AddRange(GetAllChildViews(child));
                result.AddRange(childList);
            }
            return result.Distinct().ToList();
        }
    }
    }
