    private static void OnItemsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
                Draggable draggable = (Draggable)obj;
    
                if (e.NewValue != null)
                {
                    if (((ObservableCollection<Draggable>)e.NewValue).Count > 0)
                    {
                        draggable.HasItem = true;
                        (ObservableCollection<Draggable>)e.NewValue).CollectionChanged += CollectionChanged;
                    }
                    else
                        draggable.HasItem = false;
                }
                else
                {
                    draggable.Items = new ObservableCollection<Draggable>();
                    draggable.HasItem = false;
                }
            }
    private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                
            }
