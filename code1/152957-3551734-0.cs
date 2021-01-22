    public int ChangeState(int id, int stateId)
    {
        return DbUtil.ExecuteNonQuerySp("changeDossierState", Cs, new { id, stateId });
    }
    public IEnumerable<Dossier> GetBy(int measuresetId, int measureId, DateTime month)
    {
        return DbUtil.ExecuteReaderSp<Dossier>("getDossiers", Cs, new { measuresetId, measureId, month });
    }
