    if (e.PropertyName == "Renderer")
    {
        ViewPager pager = (ViewPager)ViewGroup.GetChildAt(0);
        TabLayout layout = (TabLayout)ViewGroup.GetChildAt(1);
        for (int i = 0; i < layout.TabCount; i++)
        {
            var tab = layout.GetTabAt(i);
            var icon = tab.Icon;
            if (icon != null)
            {
                icon = Android.Support.V4.Graphics.Drawable.DrawableCompat.Wrap(icon);
                Android.Support.V4.Graphics.Drawable.DrawableCompat.SetTintList(icon, colors);
            }
        }
    }
