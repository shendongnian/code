    public object this[string propertyName] 
    { 
        get 
        { 
            PropertyInfo property = this.GetType().GetProperty(propertyName); 
            return property.GetValue(this, null); 
        } 
        set 
        { 
            PropertyInfo property = this.GetType().GetProperty(propertyName); 
            property.SetValue(this,value, null);     
        } 
}
