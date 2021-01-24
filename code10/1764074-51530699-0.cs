    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        Android.Support.V7.Widget.Toolbar toolbar;
        public CustomNavigationPageRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                this.toolbar.ChildViewAdded -= ToolbarChildAdded;
            }
            if (e.NewElement != null)
            {
                var toolbarId = Context.Resources.GetIdentifier("toolbar", "id", Context.PackageName);
                this.toolbar = this.FindViewById(toolbarId) as Android.Support.V7.Widget.Toolbar;
                this.toolbar.ChildViewAdded += ToolbarChildAdded;
            }
        }
        private void ToolbarChildAdded(object sender, ChildViewAddedEventArgs e)
        {
            if (e.Child is Android.Support.V7.Widget.AppCompatTextView tv)
            {
                // identify the title text view and center it
                tv.LayoutParameters = new Android.Support.V7.Widget.Toolbar.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent, (int)GravityFlags.CenterHorizontal);
            }
        }
    }
