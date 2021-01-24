    using System;
    using System.IO;
    
    namespace TextFileReaderTest
    {
        class Program
        {
            static char GetTerrainAt(string[] map, int x, int y)
            {
                return map[y][x];
            }
    
            static void PrintCharacter(int x, int y)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write('X');
            }
    
            static void PrintTerrainAt(string[] map, int x, int y)
            {
                char terrain = GetTerrainAt(map, x, y);
    
                switch (terrain)
                {
                    case '/':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case '^':
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case '|':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case '.':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'o':
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case '~':
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
    
                Console.SetCursorPosition(x, y);
                Console.Write(terrain);
            }
    
            static void Main()
            {
                // initialize (once)
                var map = File.ReadAllLines(@"D:\personal\tests\Tests\ascii map tools\map1.txt");
    
                var posX = 10;
                var posY = 10;
    
                Console.WindowWidth = map[0].Length; // length of first line, make sure all lines in the file are of same length
                Console.WindowHeight = map.Length; // number of lines
                Console.CursorVisible = false;
    
                // print whole map once
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    for (int y = 0; y < Console.WindowHeight; y++)
                    {
                        PrintTerrainAt(map, x, y);
                    }
                }
    
                // print character starting pos
                PrintCharacter(posX, posY);
    
                // start
                while (true)
                {
                    var input = Console.ReadKey(true);
    
                    // next move for now: stay in the same place
                    var nextX = posX;
                    var nextY = posY;
    
                    // find out where the next move will take us
                    switch (input.KeyChar)
                    {
                        case 'w':
                            nextY--;
                            break;
    
                        case 'a':
                            nextX--;
                            break;
    
                        case 's':
                            nextY++;
                            break;
    
                        case 'd':
                            nextX++;
                            break;
                    }
    
                    // make sure it's a legal move 
                    if (nextY >= Console.WindowHeight || nextY < 0 || nextX >= Console.WindowWidth || nextX < 0)
                    {
                        // illegal move, beep and continue the while loop from the top without moving the character
                        Console.Beep();
                        continue;
                    }
    
                    char terrainToMoveTo = GetTerrainAt(map, nextX, nextY);
    
                    // this should probably be moved into a function "IsTerrainPassable(terrainToMoveTo)"
                    if (terrainToMoveTo == '~')
                    {
                        // illegal move, beep and continue the while loop from the top without moving the character
                        Console.Beep();
                        continue;
                    }
    
                    // okay, legal move, move our character:
    
                    // clean up old position (if you comment this out, you will see a "snake")
                    PrintTerrainAt(map, posX, posY);
    
                    // move character
                    posX = nextX;
                    posY = nextY;
    
                    // print character at new position
                    PrintCharacter(posX, posY);
                }
            }
        }
    }
