    [assembly: ExportRenderer(typeof(NativeListView), typeof(NativeAndroidListViewRenderer))]
    namespace App2.Droid
    {
        public class NativeAndroidListViewRenderer : ListViewRenderer
        {
            public NativeAndroidListViewRenderer(Context context) : base(context)
            {
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement is NativeListView)
                    Control.Scroll += Control_Scroll;
            }
            private void Control_Scroll(object sender, AbsListView.ScrollEventArgs e)
            {
                var myList = Element as NativeListView;
                myList.IsScrolling = true;
            }
            
        }
    }
