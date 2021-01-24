    class Game
        {
            static int[,] intRaster = new int[6, 7];
            static int[] positionsDiskCount = new int[7];
    
            public static void Main()
            {
                // Array play board
                
                // playboard
                Console.WriteLine("\n\n\t\t\t        1 2 3 4 5 6 7\n");
                string strTab = "\t\t\t\t";
    
                // Displays playboard
                for (int intX = 0; intX < 6; intX++)
                {
                    Console.Write(strTab);
                    for (int intY = 0; intY < 7; intY++)
                    {
                        Console.Write(intRaster[intX, intY]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
    
                // Input
                while (true)
                {
                    MakeMove(1);
                    
                    MakeMove(2);
                    
                }
            }
    
            static private int MakeMove(int Player)
            {
                Console.Write("    \n\n\t\t\t Speler {0}: Maak uw zet!                        ", Player);
                int num = -1;
                bool moveMade = false;
                while (!moveMade)
                {
                    while (true)
                    {
                        string key = Console.ReadKey(true).KeyChar.ToString();
                        if (key == "\u001b") Environment.Exit(0);
                        if (int.TryParse(key, out num) && num > -1 && num < 8) break;
                    }
                    num--;
                    if (positionsDiskCount[num] < 6)
                    {
                        
                        intRaster[num, positionsDiskCount[num]] = Player;
                        Console.SetCursorPosition(32 + num * 2, 9 - positionsDiskCount[num]);
                        Console.Write(Player);
                        Console.SetCursorPosition(60, 10);
    
                        bool win = CheckWinner(num, positionsDiskCount[num]);
                        if (win)
                        {
                            Console.WriteLine("    \n\n\t\t\t Speler {0} has won the game!!!!!!", Player);
                            Console.WriteLine("Press any key to exit");
                            Console.ReadKey(true).KeyChar.ToString();
                            Environment.Exit(0);
                        }
    
                        positionsDiskCount[num]++;
                        moveMade = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(60, 10);
                        Console.Write("    \n\n\t\t\t ERROR: rij is vol!!!   Maak uw zet!");
                        Console.ReadKey();
                        Console.SetCursorPosition(60, 10);
                    }
                }
                return num;
            }
    
            static public bool CheckWinner(int x, int y)
            {
                //Horizontal
                int count = countDirection(x, y, -1, 0);
                count += countDirection(x, y, 1, 0);
                if (count > 2) return true;
                count = countDirection(x, y, 0, -1);
                count += countDirection(x, y, 0, 1);
                if (count > 2) return true;
                count = countDirection(x, y, -1, -1);
                count += countDirection(x, y, 1, 1);
                if (count > 2) return true;
                count = countDirection(x, y, 1, -1);
                count += countDirection(x, y, -1, 1);
                if (count > 2) return true;
                return false;
            }
    
            static public int countDirection(int x, int y, int stepX, int stepY)
            {
                int count = 0;
                int Player = intRaster[x, y];
                x += stepX;
                y += stepY;
                while (x >= 0 && x < intRaster.GetUpperBound(1) && y >= 0 && y < intRaster.GetUpperBound(0))
                {
                    if (Player == intRaster[x, y]) count++;
                    else break;
                    x += stepX;
                    y += stepY;
                }
                return count;
            }
    
        }
