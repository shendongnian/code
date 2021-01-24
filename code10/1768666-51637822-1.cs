        List<bool> Seeded = new List<bool>();
        // puts winning percentage into a list
        for (int i = 0; i < team.Count(); i++)
        {
            Seeded.Add(false);
            if(team[i].winPCT)
            {
              Seeded[i] = true;
              winPCTseed.Add(team.ElementAt(i).winPCT);
       
            }
        }
