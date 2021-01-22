    // This method gets called by the ObjectDataSource
    public Int32 Delete(MyCustomClass foo)
    {
        // But internally I call the overloaded method
        Delete(foo.Id);
    }
        
    public Int32 Delete(Int32 id)
    {
        // Delete the item
    }
