    public class DirOrFileModel
        {
            #region Private Members
    
            private string _name;
            private string _location;
            private EntryType _entryType;
    
            #endregion
    
            #region Bindings
    
            public string Name
            {
                get { return _name; }
                set
                {
                    if (value == _name) return;
                    _name = value;
                }
            }
    
            public string Location
            {
                get { return _location; }
                set
                {
                    if (value == _location) return;
                    _location = value;
                }
            }
            
            public EntryType EntryType
            {
                get { return _entryType; }
                set
                {
                    if (value == _entryType) return;
                    _entryType = value;
                }
            }
            
            public ObservableCollection<DirOrFileModel> Entries { get; set; }
    
            #endregion
    
            #region Constructor
    
            public DirOrFileModel()
            {
                Entries = new ObservableCollection<DirOrFileModel>();
            }
    
            #endregion
        }
        
        public enum EntryType
        {
            Directory = 0,
            File = 1
        }
