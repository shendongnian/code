    public class Messages : ObservableObject
    {
        readonly IDictionary<int, string> _messages = new Dictionary<int, string>();
        [IndexerName("Item")] //not exactly needed as this is the default
        public string this[int index]
        {
            get
            {
                if (_messages.ContainsKey(index))
                    return _messages[index];
    //Uncomment this if you want exceptions for bad indexes
    //#if DEBUG
    //          throw new IndexOutOfRangeException();
    //#else
                return null; //RELEASE: don't throw exception
    //#endif
            }
            set
            {
                _messages[index] = value;
                OnPropertyChanged("Item[" + index + "]");
            }
        }
    }
