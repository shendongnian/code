    public static class Twitter
    {
        public static readonly DependencyProperty InlinesProperty = DependencyProperty.RegisterAttached(
            "Inlines", typeof(ICollection<Inline>), typeof(Twitter), new PropertyMetadata(default(ICollection<Inline>), PropertyChangedCallback));
    
        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is TextBlock tb)) return;
    
            tb.Inlines.Clear();
    
            if (!(e.NewValue is ICollection<Inline> inlines)) return;
    
            foreach (var inline in inlines)
            {
                tb.Inlines.Add(inline);
            }
        }
    
        public static void SetInlines(DependencyObject element, ICollection<Inline> value)
        {
            element.SetValue(InlinesProperty, value);
        }
    
        public static ICollection<Inline> GetInlines(DependencyObject element)
        {
            return (ICollection<Inline>) element.GetValue(InlinesProperty);
        }
    }
