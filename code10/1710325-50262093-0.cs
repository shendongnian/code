    using Android.OS;
    using AppTTM_AVI.Droid;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    
    [assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
    namespace App.Droid
    {
        /// <summary>
        /// Workaround for searchBar not appearing on Android >= 7
        /// </summary>
        public class CustomSearchBarRenderer : SearchBarRenderer
        {
            public CustomSearchBarRenderer()
            {
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement != null || Element == null)
                {
                    return;
                }
    
                if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                {
                    Element.HeightRequest = 42;
                }
            }
        }
    }
