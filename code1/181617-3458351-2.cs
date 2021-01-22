        public T GetByID(int id)
        {
            return (T)context.GetObjectByKey(new EntityKey(context.DefaultContainerName 
                                                + "." + context.CreateObjectSet<T>().EntitySet.Name
                                                , GetPrimaryKey<T>(), id));            
        }
