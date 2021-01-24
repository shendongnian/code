    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int playerHp = 100;
            int enemyHp = 100;
            int playerD = rnd.Next(10, 15);
            int enemyD = rnd.Next(10, 15);
            int potion = 25;
            Console.Write("Get Ready! It's time to battle! ");
            Console.WriteLine("You stare into the eyes of the ugly goblin and are ready to slay it with your sword \n");
            do
            {
                Console.WriteLine(" what will you do now?");
                Console.WriteLine("\n 1. Attack    2. Defend    3. Use potion");
                bool isInputValid = false;
                while (isInputValid == false)
                {
                    isInputValid = true;
                    switch (Console.ReadLine())
                    {
                        case "1":
                            enemyHp -= playerD;
                            Console.WriteLine("you swung your sword and struck the goblin in the body leaving it " + enemyHp + "HP left over");
                            break;
                        case "2":
                            Console.WriteLine("You prepaired your sheild for the incoming attack");
                            break;
                        case "3":
                            playerHp += potion;
                            Console.WriteLine("You chugged down the potion as quick as you could and now have " + playerHp + " left!");
                            break;
                        default:
                            Console.WriteLine("Invalid input, please choose a listed action!");
                            isInputValid = false;
                            break;
                    }
                }
                Console.WriteLine("\nEnemy Turn!");
                playerHp -= enemyD;
                Console.WriteLine("The goblin struck you with his mace and left you with " + playerHp + "HP left!");
            } while (playerHp > 0 || enemyHp > 0);
        }
    }
