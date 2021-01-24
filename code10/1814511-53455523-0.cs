    namespace NatesFirstTextGame
    {
        class Goose 
        {
            EnemyTemplate Enemy = new EnemyTemplate();
    
            public void GooseStats()
            {
                Enemy.SetEnmName("Goose");
                Enemy.SetEnmStr(1);
                Enemy.SetEnmDex(1);
                Enemy.SetEnmConHP(1);
            }
    
    	    public string GetEnemyEnmName(){
                return Enemy.GetEnmName();
            }
    
            public int GetEnemyEnmStr()
            {
                return Enemy.GetEnmStr();
            }
        }
    }
