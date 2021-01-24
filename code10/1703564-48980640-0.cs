    public class DataGrabber : IDataGrabber
    {
        private SummonerMethod sm = new SummonerMethod();
        private MatchlistMethod mlm = new MatchlistMethod();
        private MatchMethod mm = new MatchMethod();
        public delegate Summoner GetSummoner();
        public delegate Matchlist GetMatchlist();
        public delegate Data GetAllMatchData();
        public GetSummoner Method1;
        public GetMatchlist Method2;
        public GetAllMatchData Method3;
        public DataGrabber()
        {
            Method1 = sm._GetSummoner;
            Method2 = mlm._GetMatchlist;
            Method3 = mm._GetAllMatchData;
        }
    }
