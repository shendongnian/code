    public override bool Equals(object obj)
    {
        var item = obj as Employee;
    
        if (item == null)
        {
            return false;
        }
    
        return this.ID.Equals(item.ID);
    }
