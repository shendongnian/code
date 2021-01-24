    List<Draft> _draftorder = new List<Draft>();
    
    foreach (Team t in teams)
    {
        for (int i = 1; i <= 5; i++)
        {
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
