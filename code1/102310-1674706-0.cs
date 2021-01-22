    // class that inherits generic List and hides the add item
    public class ListWithEvents<T> : List<T>
        {
            public event EventHandler ItemAdding;
            public event EventHandler ItemAdded;
    
            public new void Add(T item)
            {
                if (ItemAdding != null)
                    ItemAdding(item, EventArgs.Empty);
    
                base.Add(item);
    
                if (ItemAdded != null)
                    ItemAdded(item, EventArgs.Empty);
    
            }
        }
    
    // Using the class
    protected override void OnLoad(EventArgs e)
        {
        
            ListWithEvents<int> lstI = new ListWithEvents<int>();
            lstI.ItemAdded += new EventHandler(lstI_ItemAdded);
            lstI.ItemAdding += new EventHandler(lstI_ItemAdding);
        }
    
        void lstI_ItemAdding(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    
        void lstI_ItemAdded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
