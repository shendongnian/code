    public void CreateItem(string className)
    {    
         string classNamespaceAndName = "TestApp.Models." + className;    
         Type itemType = Type.GetType(classNamespaceAndName);    
         item = (object)Activator.CreateInstance(itemType, new Object[] { });    
         this.insert(item);
    
    }
