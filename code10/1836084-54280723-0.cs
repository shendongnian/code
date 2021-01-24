    Console.WriteLine("What is the total number of items sold?");
    int itemsSold = Convert.ToInt16(Console.ReadLine());
    int itemBonus = 50;
    
    if (itemsSold > 20)
    {
        int bonus1 = 100;
        int bonus2 = 200;
        Console.WriteLine("Your items sold bonus is {0} dollars" ,itemBonus);
        Console.WriteLine("What is the total dollar value of all items sold?");
        
        int dollarValue = Convert.ToInt16(Console.ReadLine());
        double totalEarned1 = (dollarValue * bonus1 + itemBonus);
        double totalEarned2 = (dollarValue * bonus2 + itemBonus);
        totalEarned1 = Math.Max( totalEarned1, 230 );
        totalEarned2 = Math.Max( totalEarned2, 230 );
        if (dollarValue >= 1000 && dollarValue < 5000)
        {
            Console.WriteLine("You have recieved a bonus of {0} ", bonus1);
        }
        else if (dollarValue >= 5000)
        {
            Console.WriteLine("You have recieved a bonus of {0} ", bonus2  );
        }
        else
        {
            Console.WriteLine("You have not recieved a dollar value bonus");
        }
    }
    else {
        Console.WriteLine("You have not sold enough items to recieve the item bonus");
    }
    
    Console.ReadLine();
