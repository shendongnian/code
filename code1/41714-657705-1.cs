    public class IndexerProvider : INotifyPropertyChanged {
    
        [IndexerName ("Item")]
        public object this [string key] {
            get {
                return ...;
            }
            set {
                ... = value;
                FirePropertyChanged ("Item[]");
            }
        }
    }
