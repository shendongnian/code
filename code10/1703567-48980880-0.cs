    namespace LeagueProj.DataGrabber
    {
        public class DataGrabber
        {
            private SummonerMethod sm;
            private MatchlistMethod mlm = new MatchlistMethod();
            private MatchMethod mm = new MatchMethod();
            public Summoner GetSummoner(string summonerName) { return sm._GetSummoner(summonerName); }
            private List<Matchlist> GetMatchlist(long accountId) { return mlm._GetMatchlist(accountId); }
            public List<Data> GetAllMatchData(List<Matchlist> matchlist, long accountId) { return mm._GetAllMatchData(matchlist, accountId); }
        }
    }
