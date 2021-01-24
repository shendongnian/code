    [assembly: ExportRenderer(typeof(BottomNavTabPage), typeof(BottomNavTabPageRenderer))]
    namespace Droid.CustomRenderers
    {
    public class BottomNavTabPageRenderer : TabbedPageRenderer, BottomNavigationView.IOnNavigationItemSelectedListener, BottomNavigationView.IOnNavigationItemReselectedListener
    {
        private bool _isShiftModeSet;
        public BottomNavTabPageRenderer( Context context )
            : base(context)
        {
        }
        bool BottomNavigationView.IOnNavigationItemSelectedListener.OnNavigationItemSelected( IMenuItem item )
        {
            if(item.TitleFormatted.ToString().Trim()== "YourTitleString") // Disable based on Title of the item 
            {
                return false;
            }
            if(!(this.Element as BottomNavTabPage).IsPageChangeEnabled) // Disable every tab
            {
                return false;
            }
            return true;
        }
        public void OnNavigationItemReselected( IMenuItem item )
        {
        }
        protected override void OnLayout( bool changed, int l, int t, int r, int b )
        {
            base.OnLayout(changed, l, t, r, b);
            try
            {
                if(!_isShiftModeSet)
                {
                    var children = GetAllChildViews(ViewGroup);
                    if(children.SingleOrDefault(x => x is BottomNavigationView) is BottomNavigationView bottomNav)
                    {
                        bottomNav.SetShiftMode(false, false);
                        _isShiftModeSet = true;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error setting ShiftMode: {e}");
            }
        }
        private List<View> GetAllChildViews( View view )
        {
            if(!(view is ViewGroup group))
            {
                return new List<View> { view };
            }
            var result = new List<View>();
            for(int i = 0; i < group.ChildCount; i++)
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
