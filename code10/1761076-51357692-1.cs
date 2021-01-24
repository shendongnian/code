     class ViewModel
    {
        public List<MyEntry> ListOfEntries { get; set; }
        public ViewModel()
        {
            ListOfEntries = new List<MyEntry>();
            AddDefaultEntries();
        }
        private void AddDefaultEntries()
        {
            ListOfEntries.Add(new MyEntry("Candidate1", "29"));
            ListOfEntries.Add(new MyEntry("Candidate2", "20"));
        }
    }
