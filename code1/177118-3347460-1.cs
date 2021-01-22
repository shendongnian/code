    public void Load()
    {
        using(var reader = _dbManager.ExectureReaderSProc(this.LoadProcedure, new SqlParameter[] { new SqlParameter("@parentId", _parentID) }))
        {
            Add(_entityFactory.CreateEntity(reader));
        }
    }
