    using AToolbar = Android.Support.V7.Widget.Toolbar;
    [assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(NavigationPageRendererDroid))] // APPCOMP
    ...
    public class NavigationPageRendererDroid : Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer // APPCOMP
    {
        public AToolbar toolbar;
        public Activity context;
        protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            var retVal = base.OnPushAsync(view, animated);
            context = (Activity)Xamarin.Forms.Forms.Context;
            toolbar = context.FindViewById<Android.Support.V7.Widget.Toolbar>(Droid.Resource.Id.toolbar);
            if (toolbar != null)
            {
                if (toolbar.NavigationIcon != null)
                {
                    toolbar.NavigationIcon = Android.Support.V4.Content.ContextCompat.GetDrawable(context, Resource.Drawable.Back);
                    //toolbar.SetNavigationIcon(Resource.Drawable.Back);
                }
            }
            return retVal;
        }
    }
