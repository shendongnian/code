    public int CompareTo(Match other)
    {
            Match match = obj as Match;
            if(match != null)
            {
                return (TeamHome == match.TeamHome
                && TeamAway == match.TeamAway
                && Result == match.Result
                && League.GetHashCode() == match.League.GetHashCode())
                ? 0 : -1;
            }
            return -1;   
    }
