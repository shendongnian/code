     public class MyGridView:GridView
    {
        private ScrollViewer myscrollviewer;
        public ScrollViewer MyScrollViewer
        {
            get { return myscrollviewer; }
            set { myscrollviewer = value; }
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ScrollViewer testscrollviewer = GetTemplateChild("ScrollViewer") as ScrollViewer;
            myscrollviewer = testscrollviewer;
        }
    }
