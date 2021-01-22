    public T GetSingle<T>(int primaryKey) where T : class
    {
        var q = Context.CreateObjectSet<T>().Where("it.TableNameID = @tableNameId");
        q.Parameters.Add(new ObjectParameter("tableNameId", primaryKey));
        return q.Single();
    }
