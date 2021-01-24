    public class MyListViewRenderer:ListViewRenderer
    {
        public MyListViewRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                Control.Bounces = false;
            }
        }
    }
