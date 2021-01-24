    List<DataPoint> marked = new List<DataPoint>();
    int markedStartIndex = -1;
    private void button1_Click(object sender, EventArgs e)
    {
        // I create a testperiod to remove
        DateTime dt0 = DateTime.Now.AddMonths(2);
        DateTime dt1 = dt0.AddHours(123);
        DateTime dt2 = dt0.AddHours(173);
        // convert to doubles:
        double startPeriod = dt1.ToOADate();
        double endPeriod = dt2.ToOADate();
        // short reference
        Series s = chart1.Series[0];
        // select the points in the period. pick your border conditions!
        marked = s.Points.Cast<DataPoint>()
                         .Where(x => x.XValue > startPeriod && x.XValue < endPeriod)
                         .ToList();
        if (marked.Count < 1) return;
        // remember where we started to remove
        markedStartIndex = s.Points.IndexOf(marked.First()); 
        foreach (DataPoint dp in marked) s.Points.Remove(dp);
        // Optionally 'hide' the gap line
        //if (markedStartIndex > 0) s.Points[markedStartIndex].Color = Color.Transparent;
    }
