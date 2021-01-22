    public class MyCanvas : Canvas
    {
        public event EventHandler ChildDesiredSizeChanged;
        protected override void OnChildDesiredSizeChanged(UIElement child)
        {
            if (ChildDesiredSizeChanged != null) ChildDesiredSizeChanged(child, EventArgs.Empty);
            base.OnChildDesiredSizeChanged(child);
        }
    }
