        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        while(dict.Any())
        {
            foreach(var key in dict.Keys.Reverse())
            {
                if(//conditional)
                {
                    dict.Remove(key);
                }
                else
                {
                    //do something with dict[key]
                }
            }
        }
