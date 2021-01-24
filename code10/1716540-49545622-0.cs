    class GameInfo
    {
        public string[,] monsterCards;
    	public static void GameInfo()
        {
            //Array for Monster Cards {Name, HP}
            monsterCards = new string[,] 
            { 
                { "Bob", "500" }, { "Billy", "600" }, { "Joe", "700" }, 
                { "Frank", "750" }, { "BillyBob", "850" } 
            };
        }    		
    }
