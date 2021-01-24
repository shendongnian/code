     public static void BattleStart()
     {
         BigChance();
         GameInfo CardInfo = new GameInfo();
         Random pickMonster = new Random();
         int monster = pickMonster.Next(0, (CardInfo.GetMonsterCards().Length) / 2);
     }
     
