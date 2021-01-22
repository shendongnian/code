    class FrameworkElement
    {
        // difference: use DataContextPropertyChanged as the change callback
        public static readonly DependencyProperty DataContextProperty = ...
        
        protected virtual void OnDataContextChanged(...)
        {
            // raise the DataContextChanged event
        }
        
        private static void DataContextPropertyChanged(...)
        {
            ((FrameworkElement)d).OnDataContextChanged(...);
        }
    }
    
