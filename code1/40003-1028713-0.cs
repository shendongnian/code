            public static T FindVisualParent<T>( this DependencyObject obj )
            where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent( obj );
            while ( parent != null )
            {
                T typed = parent as T;
                if ( typed != null )
                {
                    return typed;
                }
                parent = VisualTreeHelper.GetParent( parent );
            }
            return null;
        }
                    ContentPresenter foo = this.FindVisualParent<ContentPresenter>();
                Canvas.SetZIndex( foo, 99 );
