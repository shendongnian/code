    [Test]
    public void OnSave_Adds_Object_To_InsertItems_Array()
    {
         Setup();
    
         List<object> testList = new List<object>();
         myClassToBeTested     = new MyClassToBeTested(testList);
    
         // ... create audiableObject here, etc.
         myClassToBeTested.OnSave(auditableObject, null);
        
         // Check auditableObject has been added to testList
    }
