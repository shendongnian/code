    class Craps
    {
        const int dieSides = 6;
    
        int roll;
        //const int repeatGame = 1000;
    
        Random random = new Random();
        
        //start the game in the constructor:
        public Craps()
        {
           this.PlayCraps();
        }
  
        public void RollDice()
        {
            int die1 = 0;
            int die2 = 0;
    
            die1 = random.Next(6) + 1;
    
            die2 = random.Next(6) + 1;
    
            roll = die1 + die2;
            Console.WriteLine("The shooter roled: {0}", roll);
        }
    
        public void PlayCraps()
        {
            RollDice();
            int gameStatus = 0;
            int point = roll;
            int numRolls = 1;
    
            while (gameStatus < 1)
            {
    
    
                if (roll == 7 || roll == 11)
                {
                    Console.WriteLine("You won!");
                    break;
                }
                else if (roll == 2 || roll == 3 || roll == 12)
                {
                    Console.WriteLine("You lost.");
                    break;
                }
                else
                {
    
                    RollDice();
                    Console.WriteLine("The point is: {0}", point);
    
                    while (point != roll || roll != 7)
                    {
                        if (roll == point)
                        {
                            Console.WriteLine("You won!");
                            numRolls++;
                            gameStatus++;
                        }
    
                        if (roll == 7)
                        {
                            Console.WriteLine("You lost");
                            numRolls++;
                            gameStatus++;
                        }
                        RollDice();
                        numRolls++;
    
                    }
    
                }
            }
        }
    
    
    
        static void Main(string[] args)
        {
            Craps NewGame = new Craps();
            Console.ReadLine();
        }
    }
    
