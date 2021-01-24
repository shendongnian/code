    List<Draft> _draftorder = new List<Draft>();
    
    // Allow 5 rounds
    for (int i = 1; i <= 5; i++)
    {
        // Allow every team to pick some drafts
        foreach (Team t in teams)
        {
            // Limit them to a specific amount of picks per round
            for (int j = 1; j <= 10; j++)
            {
                _draftorder.Add(new Draft()
                {
                    city = t.city,
                    round = i,
                    pick = j,
                });
            }
        }
    }
