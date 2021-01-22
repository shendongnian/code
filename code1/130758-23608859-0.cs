    public class ListBoxExtenders : DependencyObject
    {
        public static readonly DependencyProperty AutoScrollToCurrentItemProperty = DependencyProperty.RegisterAttached("AutoScrollToCurrentItem", typeof(bool), typeof(ListBoxExtenders), new UIPropertyMetadata(default(bool), OnAutoScrollToCurrentItemChanged));
        public static bool GetAutoScrollToCurrentItem(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToSelectedItemProperty);
        }
        public static void SetAutoScrollToCurrentItem(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToSelectedItemProperty, value);
        }
        public static void OnAutoScrollToCurrentItemChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var listBox = s as ListBox;
            if (listBox != null)
            {
                var listBoxItems = listBox.Items;
                if (listBoxItems != null)
                {
                    var newValue = (bool)e.NewValue;
                    var autoScrollToCurrentItemWorker = new EventHandler((s1, e2) => OnAutoScrollToCurrentItem(listBox, listBox.Items.CurrentPosition));
                    if (newValue)
                        listBoxItems.CurrentChanged += autoScrollToCurrentItemWorker;
                    else
                        listBoxItems.CurrentChanged -= autoScrollToCurrentItemWorker;
                }
            }
        }
        public static void OnAutoScrollToCurrentItem(ListBox listBox, int index)
        {
            if (listBox != null && listBox.Items != null && listBox.Items.Count > index && index >= 0)
                listBox.ScrollIntoView(listBox.Items[index]);
        }
    }
