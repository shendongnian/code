    public class perListBoxHelper : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
            AssociatedObject.SizeChanged += AssociatedObject_SizeChanged;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            AssociatedObject.SizeChanged -= AssociatedObject_SizeChanged;
            base.OnDetaching();
        }
        private static void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollSelectionIntoView(sender as ListBox);
        }
        private static void AssociatedObject_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ScrollSelectionIntoView(sender as ListBox);
        }
        private static void ScrollSelectionIntoView(ListBox listBox)
        { 
            if (listBox?.SelectedItem == null)
                return;
            Action action = () =>
            {
                listBox.UpdateLayout();
                listBox.ScrollIntoView(listBox.SelectedItem);
            };
            listBox.Dispatcher.BeginInvoke(action, DispatcherPriority.ContextIdle);
        }
    }
