    _ExecutedSP = new StoredProcedure("EvaluationType_GetList", base._SPInputOutput);
    if (this.IsActive == null)
    {
    	_ExecutedSP.AddParameter("@IsActive", SqlDbType.Bit, DBNull.Value);
    }
    else
    {
    	_ExecutedSP.AddParameter("@IsActive", SqlDbType.Bit, this.IsActive);
    }
