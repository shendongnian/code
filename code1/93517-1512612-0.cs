    class Form
    {
        // ...
    }
    
    class Field
    {
        Form parent;
    
        public Field(Form parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
    
            this.parent = parent;
        }
    
        // now you can reference this.parent to get at its owning form
        // ...
    }
