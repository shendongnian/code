    public static Random randomT = new Random();
    public static List<List<string>> DivideTeams(string[] teams, int personCount)
    {
        List<List<string>> divideTeams = new List<List<string>>();
        if (teams.Length % personCount != 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        //shuffle teams 
        for(int k = teams.Length -1; k > 0; k--)
        {
            int trade = random.Next(k + 1);
            string temp = teams[trade];
            teams[trade] = teams[k];
            teams[k] = temp;
        }
        for (int j = 0; j < personCount; j++)
        {
            divideTeams.Add(new List<string>());
            for (int i = 0; i < teams.Length / personCount; i++)
            {
                divideTeams[j].Add(teams[i]);
            }
        }           
        return divideTeams;
    }
