      public class ObservableCollectionEx<T> : ObservableCollection<T> where T : INotifyPropertyChanged
      {
        public ObservableCollectionEx()
          : base()
        {
        }
    
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
          Unsubscribe(e.OldItems);
          Subscribe(e.NewItems);
          base.OnCollectionChanged(e);
        }
        protected override void ClearItems()
        {
          foreach(T element in this)
            element.PropertyChanged -= (x, y) => ContainedElementChanged(y);
          base.ClearItems();
        }
    
        private void Subscribe(System.Collections.IList iList)
        {
          if (iList != null)
          {
            foreach (T element in iList)
              element.PropertyChanged += (x, y) => ContainedElementChanged(y);
          }
        }
    
        private void Unsubscribe(System.Collections.IList iList)
        {
          if (iList != null)
          {
            foreach (T element in iList)
              element.PropertyChanged -= (x, y) => ContainedElementChanged(y);
          }
        }
    
        private void ContainedElementChanged(PropertyChangedEventArgs e)
        {
          OnPropertyChanged(e);
        }
      }
