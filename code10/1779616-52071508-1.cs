    public class ChartResult
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
        public List<string> Comments { get; set; }
    }
    
    myData.GroupBy(x => x.Date).Select(gp => new CharResult(){ X = gp.Key, Y = gp.Max(p => p.value), Comments = gp.Select(p => p.comment).ToList() })
