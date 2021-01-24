    public override bool Equals(object other)
    {
         Match match = other as Match;
         if(match != null)
         {
             return TeamHome == match.TeamHome
                && TeamAway == match.TeamAway
                && Result == match.Result
                && League.GetHashCode() == match.League.GetHashCode();
         }
         return false;
    }
