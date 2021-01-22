    public bool HasRSVP(List<RSVP> RSVPs, string userName)
    {
        foreach(RSVP r in RSVPs)
            if(r.AttendeeName.Equals(userName, StringComparison.InvariantCulture))
                return true;
        return false;
    }
