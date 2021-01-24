    [assembly: ExportRenderer(typeof(Xamarin.Forms.ListView), typeof(ListViewScrollRenderer))]
    
    namespace Glu.Droid.Renderers
    {
        public class ListViewScrollRenderer : ListViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null)
                {
                    var listView = this.Control as Android.Widget.ListView;
                    listView.NestedScrollingEnabled = true;
                }
            }
        }
    }
