      public class PreProcessBindingList<T> : IList<T>
        {
            private List<T> items = new List<T>();
    
    
            public void Add(T item)
            {
                PreProcess(item);
                items.Add(item);
    
                // Fire Item Added event
            }
        }
