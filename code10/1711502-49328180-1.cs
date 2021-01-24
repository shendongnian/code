    public override bool Equals(Match other)
    {
         return TeamHome == other.TeamHome
            && TeamAway == other.TeamAway
            && Result == other.Result
            && League.GetHashCode() == other.League.GetHashCode()
    }
