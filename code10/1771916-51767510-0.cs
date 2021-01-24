    public Originator(Series series)
    {
        //_series = series;
        foreach (var dp in series.Points) _series.Points.Add(dp.Clone());
    }
