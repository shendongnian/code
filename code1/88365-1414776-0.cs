    class MyData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // ...
        public HasListOfStrings { get { return ListOfStrings != null && 0 < ListOfStrings.Count; } }
        private void LoadListOfStrings
        {
            // ... load the list of strings ...
            if ( PropertyChanged) {
                PropertyChanged(this, "ListOfStrings");
                PropertyChanged(this, "HasListOfStrings");
            }
        }
    }
