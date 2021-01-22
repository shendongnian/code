    [OperationContract]
    public List<EntityObject> GetData()
    {
        using (TestEntities ctx = new TestEntities())
        {
            var data = from rec in ctx.Customer
                       select (EntityObject)rec;
            return data.ToList();
        }
    }
