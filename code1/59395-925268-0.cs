    partial void InsertTest(Test instance)
    {
        instance.idCol = System.Guid.NewGuid();
        this.ExecuteDynamicInsert(instance);
    }
    
    partial void UpdateTest(Test instance)
    {
        instance.changeDate = DateTime.Now;
        this.ExecuteDynamicUpdate(instance);
    }
 
