    public static class ListBoxExtensions
    {
        public static readonly DependencyProperty autoScrollProperty =
                    DependencyProperty.RegisterAttached(
                        "AutoScroll", 
                        typeof(bool), 
                        typeof(ListBoxExtensions), 
                        new PropertyMetadata(false));
          ...
    }
