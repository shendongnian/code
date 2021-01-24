    public static void BattleStart()
    {
        BigChance();
        GameInfo CardInfo = new GameInfo();
        Random pickMonster = new Random();
        int monster = pickMonster.Next(0, (CardInfo.monsterCards.Length) / 2);
    }
