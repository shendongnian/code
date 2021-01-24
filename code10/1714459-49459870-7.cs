    class DisplayOnNotify : DependencyObject
    {
        public static INotifyCollectionChanged GetObservable ( DependencyObject obj )
        {
            return (INotifyCollectionChanged)obj.GetValue ( ObservableProperty );
        }
        public static void SetObservable ( DependencyObject obj, INotifyCollectionChanged value )
        {
            obj.SetValue ( ObservableProperty, value );
        }
        // Using a DependencyProperty as the backing store for Observable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObservableProperty =
                               DependencyProperty.RegisterAttached ( "Observable", 
                                                                    typeof ( INotifyCollectionChanged ), 
                                                                    typeof ( DisplayOnNotify ), 
                                                                    new FrameworkPropertyMetadata ( propertyChangedCallback ) );
        private static void propertyChangedCallback ( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            if ( d is UIElement uiElement && e.NewValue is INotifyCollectionChanged notify )
            {
                notify.CollectionChanged += ( sender, e_ ) => uiElement.Visibility = Visibility.Visible;
            }
        }
    }
