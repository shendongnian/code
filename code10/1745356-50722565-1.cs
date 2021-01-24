    public class CustomListView : ListView
    {
        protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
        {
            //huge performance hit if next line is not commented out
            //base.OnIsKeyboardFocusWithinChanged(e);
        }
    }
