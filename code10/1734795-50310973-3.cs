    private void EnsureValidDetails(string nickname, int groupId)
    {
        if (string.IsNullOrWhiteSpace(nickname))
        {
            throw new ArgumentNullException(nameof(nickname));
        }
        else if (groupId < 0 || groupId > 100)
        {
            throw new ArgumentOutOfRangeException("GroupId must be between 0 and 100.");
        }
    }
