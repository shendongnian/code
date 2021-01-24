    public static Dictionary<string, int> PerformLookup(List<string> GameNames, Dictionary<string, int> GameLookup)
    {
    	Dictionary<string, int> gameScore = new Dictionary<string, int>();
    	int n = 0;
    	foreach(string game in gameNames)
    	{
    		if(gameScore.ContainsKey(game))
    			continue;
    		if(gameLookup.Keys.Contains(game))
    		{
    			gameScore.Add(game, gameLookup.FirstOrDefault(x=> x.Key == game).Value);
    		}          
    		else
    		{
    			n++;
    			if(gameLookup.FirstOrDefault(x=> x.Key == "Empty Game Title " + n.ToString()).Value == null)
    				n--;
    			gameScore.Add(game, gameLookup.FirstOrDefault(x=> x.Key == "Empty Game Title " + n.ToString()).Value);
    			
    		}
    	}   
    	
    	foreach(var t in gameScore)
    	{
    		Console.WriteLine(t);
    	}
    	
    	return gameScore;
    }
