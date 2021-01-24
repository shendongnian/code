    public List<List<double>> DistinctBy(List<List<double>> list)
    {
        var rs =new List<List<double>>();
        for(int i = 0; i < genesUsingCrossover.Count(); i++)
        {
            var flag = false;
            for(int j = i+1; j < genesUsingCrossover.Count(); j++)
            {
              if(IsSame(genesUsingCrossover[i], genesUsingCrossover[j]))
              {
                  flag =true;
                  Break;
              }
            }
            if(!flag)
              rs.Add(genesUsingCrossover[i]);
        }
        return rs;
    
    }
