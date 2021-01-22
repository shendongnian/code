    public bool Load<T>() where T : EntityBase, new()
    {
        ...
        using (IDataReader reader = _dbManager.ExectureReaderSProc(
            this.LoadProcedure, new SqlParameter[] {new SqlParameter("@parentId", _parentID) })) {
            EntityBase entity = new T();
            entity.SetReader(reader);
            this.Add(entity);
        }
        ...
    }
