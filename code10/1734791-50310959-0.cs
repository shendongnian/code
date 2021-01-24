    private bool checkUserDetails (String nickname, String groupId, out String message)
    {
        if (String.IsNullOrEmpty (nickname))
        {
            message = "Invalid nickname!";
            return false;
        }
        //and so on
    }
