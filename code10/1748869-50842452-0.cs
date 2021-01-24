    public static Random randomT = new Random();
    public static List<List<string>> DivideTeams(string[] teams, int personCount)
    {
        List<List<string>> divideTeams = new List<List<string>>();
        if (teams.Length % personCount != 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        for (int j = 0; j < personCount; j++)
        {
            divideTeams.Add(new List<string>());
            for (int i = 0; i < teams.Length / personCount; i++)
            {
                divideTeams[j].Add(teams[randomT.Next(teams.Length)]);
            }
        }           
        return divideTeams;
    }
