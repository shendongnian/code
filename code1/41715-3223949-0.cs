    public class IndexerProvider : INotifyPropertyChanged {
    
        [IndexerName("myIndexItem")]
        public object this [string key] {
            get {
                return ...;
            }
            set {
                ... = value;
                FirePropertyChanged ("myIndexItem[]");
            }
        }
    }
