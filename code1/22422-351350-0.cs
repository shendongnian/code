       private Collection<T> internalCollection;
        
        public Collection<T> GetDistinctList<T>()
        {
            List<string> names = new List<string>();
            foreach(T thisT in internalCollection)
               if (!names.Contains(thisT.Name)
               {
                   names.Add(thisT.Name);
                   yield return thisT;
               }
        }
    
