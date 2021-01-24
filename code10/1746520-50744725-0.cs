    public void RetrieveDriftData(string driftID)
    {
        string sql = $"SELECT * FROM {driftID}";
        GameManager.Drift = dbManager.Query<Drift>(sql);
        var driftList = GameManager.Drift.ToList();
    }
