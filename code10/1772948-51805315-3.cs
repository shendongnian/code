    public static class ListBoxExtensions
    {
        public static readonly DependencyProperty autoScrollProperty =
            DependencyProperty.RegisterAttached(
                "AutoScroll",
                typeof(bool),
                typeof(ListBoxExtensions),
                new PropertyMetadata(false, AutoScrollChangedCallback));
    
        public static void SetAutoScroll(ListBox element, bool value)
        {
            element.SetValue(autoScrollProperty, value);
        }
    
        public static bool GetAutoScroll(ListBox element)
        {
            return (bool)element.GetValue(autoScrollProperty);
        }
        private static void AutoScrollChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox control = (ListBox)d;
    
            if ((bool)e.NewValue)
            {
                control.SelectionChanged += Element_SelectionChanged;
            }
            else
            {
                control.SelectionChanged -= Element_SelectionChanged;
            }
        }
    
        private static void Element_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            listBox.ScrollIntoView(listBox.SelectedItem);
        }
    }
