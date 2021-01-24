    [assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
    namespace{
      public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        private TabLayout TabsLayout { get; set; }
        private ViewPager PagerLayout { get; set; }
        public CustomTabbedPageRenderer( Context context ) : base(context)
        {
        }
        protected override void OnElementChanged( ElementChangedEventArgs<TabbedPage> e )
        {
            base.OnElementChanged(e);
            for(int i = 0; i < ChildCount; ++i)
            {
                Android.Views.View view = (Android.Views.View)GetChildAt(i);
                if(view is TabLayout)
                    TabsLayout = (TabLayout)view;
            }
            if(TabsLayout!=null) //now disable the tap event
            {
                DisableTab((Element as CustomTabbedPage).TabNumber);
            }
        }
        private void DisableTab( int tabNumber )
        {
            if(tabNumber==int.MinValue) return;
            ViewGroup vg = (ViewGroup)TabsLayout.GetChildAt(0);
            ViewGroup vgTab = (ViewGroup)vg.GetChildAt(tabNumber);
            vgTab.Enabled=(false);
        }
    }
    }
