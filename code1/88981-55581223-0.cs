    public static class ObservableCollectionEx
    {
        public static void SetOnCollectionItemPropertyChanged<T>(this T _this, PropertyChangedEventHandler handler)
            where T : INotifyCollectionChanged, ICollection<INotifyPropertyChanged> 
        {
            _this.CollectionChanged += (sender,e)=> {
                if (e.NewItems != null)
                {
                    foreach (Object item in e.NewItems)
                    {
                        ((INotifyPropertyChanged)item).PropertyChanged += handler;
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (Object item in e.OldItems)
                    {
                        ((INotifyPropertyChanged)item).PropertyChanged -= handler;
                    }
                }
            };
        }
    }
