    public class Test
    {
        public EventHandler InitializeCompleted;
    
        int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                CheckAllProperties();
            }
        }
        string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                CheckAllProperties();
            }
        }
    
        HashSet<string> _initialized = new HashSet<string();
        void CheckAllProperties([CallerMemberName] string property = null)
        {
            if(_initialized == null) // ignore calls after initialization is done
                return;
            _initialized.Add(property);
            if(_initialized.Count == 2) // all properties setters were called
            {
                _initialized = null;
                InitializeCompleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
