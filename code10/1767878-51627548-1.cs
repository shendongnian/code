    public void InsertNewRecord(TestClass newClass){
        newClass.externalClass = context.Where(e => e.ID = newClass.externalClass.Id).First();
        context.Add(newClass);
        context.SaveChanges();        
    }
