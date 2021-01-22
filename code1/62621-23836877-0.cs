        public static IEnumerable<T> FindLogicalChildren<T> ( DependencyObject depObj ) where T : DependencyObject {
            if( depObj != null ) {
                foreach( object rawChild in LogicalTreeHelper.GetChildren( depObj ) ){
                    if( rawChild is DependencyObject ) {
                        DependencyObject child = (DependencyObject)rawChild;
                        if( child is T ) {
                            yield return (T)child;
                        }
                        foreach( T childOfChild in FindLogicalChildren<T>( child ) ) {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
