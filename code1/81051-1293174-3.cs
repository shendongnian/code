    public void ListMatches(List<string> ListTeam)
    {
        if (ListTeam.Count % 2 != 0)
        {
            ListTeam.Add("Bye");
        }
        int numDays = (numTeams - 1);
        int halfSize = numTeams / 2;
        List<string> teams = new List<string>();
	
        teams.AddRange(ListTeam.Skip(halfSize).Take(halfSize));
        teams.AddRange(ListTeam.Skip(1).Take(halfSize -1).ToArray().Reverse());
		
        for (int day = 0; day <= numDays; day++)
        {
            Console.WriteLine("Day {0}", day);
	
            int teamIdx = day % numDays;
            Console.WriteLine("{0} vs {1}", teams[teamIdx], ListTeam[0]);
		
            for (int idx = 1; idx < halfSize; idx++)
            {				
                int firstTeam = (day + idx) % numDays;
                int secondTeam = (day  + numDays - idx) % numDays;
                Console.WriteLine("{0} vs {1}", teams[firstTeam], teams[secondTeam]);
            }
        }
    }
