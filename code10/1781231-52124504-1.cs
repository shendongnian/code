    public void SoldItems()
    {
        do
        {
            DisplayInventory();
            int userSelection = int.Parse(Console.ReadLine());
            switch (userSelection)
            {
                case 1:
                    Money.MoneyAddition(goldPrice, 1);
                    Console.WriteLine(Money.userMoney);
                    break;
                case 2:
                    Money.MoneyAddition(silverPrice, 1);
                    Console.WriteLine(Money.userMoney);
                    break;
                case 3:
                    Money.MoneyAddition(titaniumPrice, 1);
                    Console.WriteLine(Money.userMoney);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        while (true);
    }
