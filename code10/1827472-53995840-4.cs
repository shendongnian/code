    [Authorize(Policy = PolicyTypes.Users.Manage)]
    public async Task<IEnumerable<TeamDto>> GetSubTeams(int parentId)
    {
        var teams = await _teamService.GetSubTeamsAsync(parentId);
        return teams;
    }
