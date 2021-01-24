    private void EnsureValidDetails(string nickname, string groupId)
    {
        if (string.IsNullOrWhiteSpace(nickname))
        {
            throw new ArgumentNullException(nameof(nickname));
        }
        else if (string.IsNullOrEmpty(groupId))
        {
            throw new ArgumentNullException(nameof(groupId));
        }
        int parsedGroupId;
        if (!int.TryParse(groupId, out parsedGroupId))
        {
            // or some better wording
            throw new ArgumentException("GroupId is not a valid number."); 
        }
        if (parsedGroupId < 0 || parsedGroupId > 100)
        {
            throw new ArgumentOutOfRangeException("GroupId must be between 0 and 100.");
        }
    }
