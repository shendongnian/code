    public void Tables<TTableType>(string TableName)
    {
         using (EntityModel entity = new EntityModel())
         {
                      ObjectQuery<TTableType> oq = new ObjectQuery<TTableType>("EntityModel." + TableName, entity);       
                var q = (from p in oq select p);
            }
        }
