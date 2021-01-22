      public class PreProcessBindingList<T> : Collection<T>
        {   
            public AddingNewEventHandler AddingNew;
            public override void Add(T item)
            {
                PreProcess(item);
                base.Add(item);
    
                AddingNewEventHandler addingNew = this.AddingNew;
                if (addingNew != null)
                {
                    addingNew(this, new AddingNewEventArgs(item));
                }
            }
        }
