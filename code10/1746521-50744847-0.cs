    using System;
    using System.Collections.Generic;
    List<Drift > driftList = new List<Drift>();
    ...
    public void RetrieveDriftData(string driftID)
    {
        string sql = "SELECT * FROM \"" + driftID + "\" ";
        GameManager.Drift = dbManager.Query<Drift>(sql);
        foreach (Drift drift in GameManager.Drift)
        {
            Debug.Log(drift.DriftStep);
            driftList.Add(drift);
        }
    }
