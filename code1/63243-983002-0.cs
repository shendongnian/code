    public class CollectionOfChild
    {
        public void Add(Child c)
        {
            this._Collection.Add(c);
            try
            {
                c.UpdateParent(this);
            }
            catch
            {
                // Failed to update parent
                this._Collection.Remove(c);
            }
        }
        public void Remove(Child c)
        {
            this._Collection.Remove(c);
            c.RemoveParent(this);
        }
    }
    public class Child
    {
        public void UpdateParent(CollectionOfChild col)
        {
            if (col.Contains(this))
            {
                this._Parent = col;
            }
            else
            {
                throw new Exception("Only collection can invoke this");
            }
        }
        public void RemoveParent(CollectionOfChild col)
        {
            if (this.Parent != col)
            {
                throw new Exception("Removing parent that isn't the parent");
            }
            this._Parent = null;
        }
    }
