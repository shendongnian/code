    public override bool Equals(object other)
    {
         Match match = other as Match;
         if(match != null)
         {
             return TeamHome == other.TeamHome
                && TeamAway == other.TeamAway
                && Result == other.Result
                && League.GetHashCode() == other.League.GetHashCode()
         }
         return false;
    }
