    var parentType = typeof(DailyStat);
    var keyType = parentType.GetNestedType("DailyKeyStat", BindingFlags.NonPublic); 
    //edited to use GetNestedType instead of just NestedType
    
    var privateKeyInstance = new PrivateObject(Activator.CreateInstance(keyType, true));
    
    privateKeyInstance.SetProperty("Date", DateTime.Now);
    privateKeyInstance.SetProperty("Type", StatType.Foo);
    
    var hashCode = (int)privateKeyInstance.Invoke("GetHashCode", null);
