    [assembly:ExportRenderer(typeof(SearchBar), typeof(MySearchBarRenderer))]
    namespace yourprjectnamespace
    {
        public class MySearchBarRenderer : SearchBarRenderer
        {
            public MySearchBarRenderer(Context context) : base(context)
            {
            }
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
            {
                base.OnElementChanged(e);
    
                if (Control != null)
                {
                    var searchView = Control;
                    int searchViewCloseButtonId = Control.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
                    var closeIcon = searchView.FindViewById(searchViewCloseButtonId);
                    (closeIcon as ImageView).SetImageResource(Resource.Mipmap.icon);
                }
            }
        }
    }
