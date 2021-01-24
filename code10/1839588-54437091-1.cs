    public class SpanishSeasonTableTeamObjectComparer : IComparer<SeasonTableTeamObject>
    {
        public Compare(SeasonTableTeamObject x, SeasonTableTeamObject y)
        {
             if(x.Points != y.Points)
             {
                 return x.Points.CompareTo(y.Points);
             }
             
             // stack your various comparisons here, pattern like above...
    
             // if everything above is equal, compare on goals
             return x.Goals.CompareTo(y.Goals);
        }
    }
