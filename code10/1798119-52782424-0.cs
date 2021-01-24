    for (int i = 0; i < 300; i++)
    {
        for (int j = 0; j < 300; j++)
        {
            if (string.IsNullOrEmpty(screeny_baza[i,j]))
            {
                continue;
            }
                list.Add(screeny_baza[i, j]);
        }
    }
