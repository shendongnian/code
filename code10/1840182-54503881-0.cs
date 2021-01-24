    private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MultiSelectComboBox control = (MultiSelectComboBox)d;
    
                var action = new NotifyCollectionChangedEventHandler(
                    (o, args) =>
                    {
                        MultiSelectComboBox c = (MultiSelectComboBox)d;
    
                        c?.DisplayInControl();
                    });
    
                if (e.OldValue != null)
                {
                    var sourceCollection = (ObservableDictionary<string, object>)e.OldValue;
                    sourceCollection.CollectionChanged -= action;
                }
    
                if (e.NewValue != null)
                {
                    var sourceCollection = (ObservableDictionary<string, object>)e.NewValue;
                    sourceCollection.CollectionChanged += action;
                }
    
                control.DisplayInControl();
            }
