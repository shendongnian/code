    bool IsMatch(sessionModel, name)
    {
        var groupToMatch = _sessionModel.Groups.OfType<IFoo>().SingleOrDefault();
        if (groupToMatch != null) 
        {
            if (Name.Equals(groupToMatch.MemberGroup, StringComparison.OrdinalIgnoreCase)) 
            {
                return true;
            }
        }
        return false;
    }
    viewModel.IsMember = IsMatch(_sessionModel, Name);
