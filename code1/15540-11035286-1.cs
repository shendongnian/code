        public void AddToArray(string[] options)
        {
            // Add one item
            options = options.AddToArray("New Item");
            // Add a 
            options = options.AddRangeToArray(new string[] { "one", "two", "three" });
            // Do stuff...
        }
