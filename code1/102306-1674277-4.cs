      public class PreProcessBindingList<T> : IList<T>
        {
            private List<T> items = new List<T>();
    
            public AddingNewEventHandler AddingNew;
            public void Add(T item)
            {
                PreProcess(item);
                items.Add(item);
    
                AddingNewEventHandler addingNew = this.AddingNew;
                if (addingNew != null)
                {
                    addingNew(this, new AddingNewEventArgs(item));
                }
            }
        }
