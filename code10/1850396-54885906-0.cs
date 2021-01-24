    void UpdateValue(string someString, Class1 value)
    {
        using (var dbContext = new DbContext())
        {
            Class2 fetchedData = dbContext.Class2.Where(...).FirstOrDefault();
            if (fetchedData != null)
            {   // data exists. Update the properties
                fetchedData.Prop1 = value.Prop1,
                fetchedData.Prop2 = value.Prop2,
                fetchedData.Prop3 = value.Prop3,
                // future version of Class2 may have properties that are not updated
                // no need to set state to modified. Entity Framework will detect the changes
                dbContext.SaveChanges();
            }
        }
    }
