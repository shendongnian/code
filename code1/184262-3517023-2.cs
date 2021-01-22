    public static class DependencyObjectExtensions
    {
        public static TItem FindParent<TItem>( this DependencyObject dependencyObject )
            where TItem : class
        {
            TItem parent = null;
    
            DependencyObject possibleParent = dependencyObject;
            while( parent == null && possibleParent != null )
            {
                parent = possibleParent as TItem;
                possibleParent = VisualTreeHelper.GetParent( possibleParent );
            }
    
            return parent;
        }
    }
