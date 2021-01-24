    string line = Console.ReadLine();
    if (line == "1")
    {
        enemyHp -= playerD;
        Console.WriteLine("you swung your sword and struck the goblin in the body leaving it " + enemyHp + "HP left over");
    }
    else if (line == "2")
    {
        Console.WriteLine("You prepaired your sheild for the incoming attack");
    }
    else if (line == "3")
    {
        playerHp += potion;
        Console.WriteLine("You chugged down the potion as quick as you could and now have " + playerHp + " left!" );
    }
