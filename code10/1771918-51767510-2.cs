    public void RestoreSeries(Memento m)
    {
        // this._series = m.MMseries;
        this._series.Points.Clear();
        foreach (var dp in m.MMseries.Points) this._series.Points.Add(dp);
    }
