    public class Invasion : INotifyCollectionChanged
    {
       private ObservableCollection<FearCard> _fearDeck = new ObservableCollection<FearCard>();
       public event NotifyCollectionChangedEventHandler CollectionChanged
       {
           add { _fearDeck.CollectionChanged += value; }
           remove { _fearDeck.CollectionChanged -= value; }
       }
       ...
    }
