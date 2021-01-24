    [assembly: ExportRenderer(typeof(SWTabSelection.MainPage), typeof(SWTabSelection.Droid.MyTabbedPageRenderer))]
    namespace SWTabSelection.Droid
    {
        public class MyTabbedPageRenderer : TabbedPageRenderer, TabLayout.IOnTabSelectedListener
        {
            private ViewPager viewPager;
            private TabLayout tabLayout;
            private bool setup;
            public MyTabbedPageRenderer() { }
            public MyTabbedPageRenderer(Context context) : base(context)
            {
                //Use this constructor for newest versions of XF saving the context parameter 
                // in a field so it can be used later replacing the Xamarin.Forms.Forms.Context which is deprecated.
            }
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == "Renderer")
                {
                    viewPager = (ViewPager)ViewGroup.GetChildAt(0);
                    tabLayout = (TabLayout)ViewGroup.GetChildAt(1);
                    setup = true;
                    ColorStateList colors = GetTabColor();
                    for (int i = 0; i < tabLayout.TabCount; i++)
                    {
                        var tab = tabLayout.GetTabAt(i);
                        SetTintColor(tab, colors);
                    }
                }
            }
        void TabLayout.IOnTabSelectedListener.OnTabReselected(TabLayout.Tab tab)
        {
            // To have the logic only on he tab on position 1
            if(tab == null || tab.Position != 1)
            {
                return;
            }
            if(tab.Text == "Play")
            {
                tab.SetText("Pause");
                tab.SetIcon(Resource.Drawable.ionicons_2_0_1_pause_outline_25);
                App.pauseCard = false;
            }
            else
            {
                tab.SetText("Play");
                tab.SetIcon(Resource.Drawable.ionicons_2_0_1_play_outline_25);
                App.pauseCard = true;
            }
            SetTintColor(tab, GetTabColor());
        }
            void SetTintColor(TabLayout.Tab tab, ColorStateList colors)
            {
                var icon = tab?.Icon;
                if(icon != null)
                {
                    icon = Android.Support.V4.Graphics.Drawable.DrawableCompat.Wrap(icon);
                    Android.Support.V4.Graphics.Drawable.DrawableCompat.SetTintList(icon, colors);            
                }
            }
            ColorStateList GetTabColor()
            {
                return ((int)Build.VERSION.SdkInt >= 23) 
                    ? Resources.GetColorStateList(Resource.Color.icon_tab, Forms.Context.Theme)
                                   : Resources.GetColorStateList(Resource.Color.icon_tab);
            }
        }
    }
