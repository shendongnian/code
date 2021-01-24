        List <Array> Agrigrate = new List<Array>();
        foreach (foo i in bar)
        {
            foreach(foo j in bar)
            {
                if(i.ID != j.ID && i.Name.Contains(j.Name))
                {
                    Agrigrate.Add(new Array[i, j]);
                }
            }
        }
