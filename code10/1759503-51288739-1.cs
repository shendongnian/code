        public class ItemsChangeObservableCollection<T> :
               System.Collections.ObjectModel.ObservableCollection<T> where T : INotifyPropertyChanged
        {
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    RegisterPropertyChanged(e.NewItems);
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    UnRegisterPropertyChanged(e.OldItems);
                }
                else if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    UnRegisterPropertyChanged(e.OldItems);
                    RegisterPropertyChanged(e.NewItems);
                }
    
                base.OnCollectionChanged(e);
            }
    
            protected override void ClearItems()
            {
                UnRegisterPropertyChanged(this);
                base.ClearItems();
            }
    
            private void RegisterPropertyChanged(IList items)
            {
                foreach (INotifyPropertyChanged item in items)
                {
                    if (item != null)
                    {
                        item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
            }
    
            private void UnRegisterPropertyChanged(IList items)
            {
                foreach (INotifyPropertyChanged item in items)
                {
                    if (item != null)
                    {
                        item.PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
            }
    
            private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                //launch an event Reset with name of property changed
                base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }
        private ItemsChangeObservableCollection<AnnotationBreakDown> _stabBreakdown = new ItemsChangeObservableCollection<AnnotationBreakDown>();
        public ItemsChangeObservableCollection<AnnotationBreakDown> StabCollection
        {
            get { return _stabBreakdown;}
            set { _stabBreakdown = value; }
        }
