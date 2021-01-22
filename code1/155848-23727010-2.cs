    public class MRUList : ObservableCollection<MRUListItem>
    {
        //  The owning ViewModel provides us with his FileOpenCommand
        //  initially. 
        public MRUList(ICommand fileOpenCommand)
        {
            FileOpenCommand = fileOpenCommand;
            CollectionChanged += CollectionChangedHandler;
        }
        public ICommand FileOpenCommand { get; protected set; }
        //  Methods to renumber and prune when items are added, 
        //  remove duplicates when existing item is re-added, 
        //  and to assign FileOpenCommand to each new MRUListItem. 
        //  etc. etc. etc. 
    }
    public class MRUListItem : INotifyPropertyChanged
    {
        public ICommand FileOpenCommand { get; set; }
        private int _number;
        public int Number {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
                OnPropertyChanged("HeaderText");
            }
        }
        public String HeaderText { 
            get {
                return String.Format("_{0} {1}", Number, FileName);
            }
        }
        //  etc. etc. etc. 
    }
