        /// <summary>
        /// Update catalog; keeps track of update entity instances.
        /// </summary>
        private Dictionary<object, HashSet<string>> updates 
            = new Dictionary<object, HashSet<string>>();
        public void UpdateNotification(object sender, PropertyChangedEventArgs e)
        {
            T source = (T)sender;
            if (!updates.ContainsKey(source))
                updates.Add(source, new HashSet<string>());
            updates[source].Add(e.PropertyName);
        }
