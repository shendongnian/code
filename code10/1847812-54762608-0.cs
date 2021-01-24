    public bool CheckValue()
    {
           return this.GetType().GetProperties()
                   .Where(property=> property.Name.StartsWith("Value"))
                   .Count(property=>property.GetValue(this,null)!=null)>=1;
    
    }
