    public static bool IsAllowed(int userID)
    {
        return (Personnel.Contains(userID))
    }
    public bool Contains(int userID) : extends Personnel (i think that is how it is written)
    {
        foreach (int id in Personnel)
            if (id == userid)
                return true;
        return false;
    }
