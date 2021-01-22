    public static bool operator ==(RRWinRecord lhs, RRWinRecord rhs)
    {
        if (object.ReferenceEquals(lhs, rhs))
        {
            return true;
        }
        else if ((object)lhs == null || (object)rhs == null)
        {
            return false;
        }
        else
        {
            return lhs.Wins == rhs.Wins &&
                lhs.Losses == rhs.Losses &&
                lhs.Draws == rhs.Draws &&
                lhs.OverallScore == rhs.OverallScore;
        }
    }
