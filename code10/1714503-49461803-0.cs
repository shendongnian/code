    private List<String> OrderList(List<String> teams, int[] positions)
    {
        List<String> orderedTeams;
        Dictionary<int, string> teamsToOrder = new Dictionary<int, string>();
        int position = 0;
        foreach (string team in teams)
        {
            teamsToOrder.Add(positions[position], teams[position]);
            position = position + 1; 
        }
        orderedTeams = teamsToOrder.OrderByDescending(team => team.Key).Select(team => team.Value).ToList();
            return orderedTeams;
        }
