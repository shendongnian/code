        List<bool> Seeded = new List<bool>();
        // puts winning percentage into a list
        for (int i = 0; i < team.Count(); i++)
        {
            winPCTseed.Add(team.ElementAt(i).winPCT);
            Seeded.Add(true);
        }
