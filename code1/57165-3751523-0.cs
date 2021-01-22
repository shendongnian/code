    internal static class CanvasAssistant
    {
        #region Dependency Properties
    
        public static readonly DependencyProperty BoundChildrenProperty =
            DependencyProperty.RegisterAttached("BoundChildren", typeof (object), typeof (CanvasAssistant),
                                                new FrameworkPropertyMetadata(null, onBoundChildrenChanged));
    
        #endregion
    
        public static void SetBoundChildren(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(BoundChildrenProperty, value);
        }
    
        private static void onBoundChildrenChanged(DependencyObject dependencyObject,
                                                   DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject == null)
            {
                return;
            }
            var canvas = dependencyObject as Canvas;
            if (canvas == null) return;
    
            var objects = (ObservableCollection<UIElement>) e.NewValue;
    
            if (objects == null)
            {
                canvas.Children.Clear();
                return;
            }
    
            //TODO: Create Method for that.
            objects.CollectionChanged += (sender, args) =>
                                                {
                                                    if (args.Action == NotifyCollectionChangedAction.Add)
                                                        foreach (object item in args.NewItems)
                                                        {
                                                            canvas.Children.Add((UIElement) item);
                                                        }
                                                    if (args.Action == NotifyCollectionChangedAction.Remove)
                                                        foreach (object item in args.OldItems)
                                                        {
                                                            canvas.Children.Remove((UIElement) item);
                                                        }
                                                };
    
            foreach (UIElement item in objects)
            {
                canvas.Children.Add(item);
            }
        }
    }
