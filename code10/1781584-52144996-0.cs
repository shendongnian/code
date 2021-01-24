    class Program
    {
        static void Main()
        {
            Settings.ScreenSettings();
            ArmyOfInvaders.InitializeArmyOfInvaders();
            Player.InitializePlayer();
            int stepCount = 0;
            int armyOfInvadersSpeed = 50;
            while (true)
            {
                stepCount++;
                if (stepCount % armyOfInvadersSpeed == 0)
                {
                    Draw.EraseItem(ArmyOfInvaders.armyOfInvaders);
                    
                    ArmyOfInvaders.armyOfInvaders.Clear();
                    ArmyOfInvaders.InitializeArmyOfInvaders(Movement.moveY, Movement.moveX);
                    Movement.MovementArmyOfInvaders();
                    stepCount = 0;
                }
                Console.CursorVisible = false;
                Draw.DrawItem(ArmyOfInvaders.armyOfInvaders);
                Draw.EraseItem(Player.player);
                Shoot.GenerateShot();
                Movement.MovementPlayer();
                Draw.DrawItem(Player.player);
                Draw.DrawShoot();
                Draw.EraseShoot();
                Collision.InvaderGotShot();
                Thread.Sleep(Common.gameSpeed);
            }
        }
    }
    public class Settings
    {
        static public int maxRows = 50;
        static public int maxCols = 180;
        public static void ScreenSettings()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight = maxRows;
            Console.BufferWidth = Console.WindowWidth = maxCols;
        }
    }
    public struct Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public char Symbol { get; set; }
        public Position(int row, int col, char symbol)
        {
            this.Row = row;
            this.Col = col;
            this.Symbol = symbol;
        }
    }
    public class Player
    {
        public static List<Position> player = new List<Position>();
        public static int playerWide = 9;
        public static int playerLong = player.Count;
        public static List<Position> InitializePlayer(int row = 0, int col = 0)
        {
            int startrow = Settings.maxRows - 5 - playerLong;//start position row
            int startcol = (Settings.maxCols / 2) - (playerWide / 2);// start position col
            player.Add(new Position(startrow + row, startcol + col, 'A'));
            player.Add(new Position(startrow + 1 + row, startcol + col, 'o'));
            player.Add(new Position(startrow + 2 + row, startcol - 2 + col, '|'));
            player.Add(new Position(startrow + 2 + row, startcol + col, 'o'));
            player.Add(new Position(startrow + 2 + row, startcol + 2 + col, '|'));
            player.Add(new Position(startrow + 3 + row, startcol - 4 + col, '/'));
            player.Add(new Position(startrow + 3 + row, startcol - 3 + col, '\\'));
            player.Add(new Position(startrow + 3 + row, startcol - 2 + col, '\\'));
            player.Add(new Position(startrow + 3 + row, startcol - 1 + col, '\\'));
            player.Add(new Position(startrow + 3 + row, startcol + col, 'o'));
            player.Add(new Position(startrow + 3 + row, startcol + 1 + col, '/'));
            player.Add(new Position(startrow + 3 + row, startcol + 2 + col, '/'));
            player.Add(new Position(startrow + 3 + row, startcol + 3 + col, '/'));
            player.Add(new Position(startrow + 3 + row, startcol + 4 + col, '\\'));
            player.Add(new Position(startrow + 4 + row, startcol - 2 + col, '<'));
            player.Add(new Position(startrow + 4 + row, startcol - 1 + col, '/'));
            player.Add(new Position(startrow + 4 + row, startcol - 0 + col, 'o'));
            player.Add(new Position(startrow + 4 + row, startcol + 1 + col, '\\'));
            player.Add(new Position(startrow + 4 + row, startcol + 2 + col, '>'));
            return player;
        }
    }
    public class Movement
    {
        public static bool isRight = true;
        public static int moveX = 0;
        public static int moveY = 0;
        public static int left = -1;
        public static int right = 1;
        public static int armyOfInvaderJump = 5;
        public static void MovementArmyOfInvaders()
        {
            if (isRight)
            {
                moveX += armyOfInvaderJump;
                if (ArmyOfInvaders.armyOfInvaders[ArmyOfInvaders.armyOfInvaders.Count - 1][9].Col >= Settings.maxCols - 20)
                {
                    isRight = false;
                    moveY += 2;
                }
            }
            else
            {
                moveX -= armyOfInvaderJump;
                if (ArmyOfInvaders.armyOfInvaders[0][0].Col <= 20)
                {
                    isRight = true;
                    moveY += 2;
                }
            }
        }
        public static void MovementPlayer()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (Player.player[0].Col - 6 >= 0)
                {
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        for (int i = 0; i < Player.player.Count; i++)
                        {
                            Player.player[i] = new Position(Player.player[i].Row, Player.player[i].Col + left, Player.player[i].Symbol);
                        }
                    }
                }
                if (Player.player[0].Col + 7 < Settings.maxCols)
                {
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        for (int i = 0; i < Player.player.Count; i++)
                        {
                            Player.player[i] = new Position(Player.player[i].Row, Player.player[i].Col + right, Player.player[i].Symbol);
                        }
                    }
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Shoot.shoot[Player.player[0].Row - 1, Player.player[0].Col] = 1;
                }
            }
        }
    }
    class Shoot
    {
        public static int[,] shoot = new int[Settings.maxRows, Settings.maxCols];
        public static void GenerateShot()
        {
            for (int Row = 0; Row < Shoot.shoot.GetLength(0); Row++)
            {
                for (int Col = 0; Col < Shoot.shoot.GetLength(1); Col++)
                {
                    if (Shoot.shoot[Row, Col] == 1 && (Row == 0))
                    {
                        Shoot.shoot[Row, Col] = 0;
                    }
                    if (Shoot.shoot[Row, Col] == 1)
                    {
                        Shoot.shoot[Row, Col] = 0;
                        Shoot.shoot[Row - 1, Col] = 1;
                    }
                }
            }
        }
    }
    static public class Invader
    {
        public static List<Position> InitializeInvader(int row, int col)
        {
            int startrow = 5;//start position row
            int startcol = ArmyOfInvaders.startArmyOfInvadersPosition;// start position col
            List<Position> invader = new List<Position>();
            invader.Add(new Position(startrow + row, startcol + col, '/'));
            invader.Add(new Position(startrow + row, startcol + 1 + col, '{'));
            invader.Add(new Position(startrow + row, startcol + 2 + col, 'O'));
            invader.Add(new Position(startrow + row, startcol + 3 + col, '}'));
            invader.Add(new Position(startrow + row, startcol + 4 + col, '\\'));
            invader.Add(new Position(startrow + 1 + row, startcol + col, '\\'));
            invader.Add(new Position(startrow + 1 + row, startcol + 1 + col, '~'));
            invader.Add(new Position(startrow + 1 + row, startcol + 2 + col, '$'));
            invader.Add(new Position(startrow + 1 + row, startcol + 3 + col, '~'));
            invader.Add(new Position(startrow + 1 + row, startcol + 4 + col, '/'));
            return invader;
        }
    }
    public class Draw
    {
        public static void DrawItem(List<Position> invader)
        {
            ;
            foreach (Position part in invader)
            {
                Console.SetCursorPosition(part.Col, part.Row);
                Console.Write((char)part.Symbol);
            }
        }
        public static void DrawItem(List<List<Position>> armyOfInvaders)
        {
            for (var i = 0; i < armyOfInvaders.Count; i++)
            {
                if (!ArmyOfInvaders.deadInvaders.Contains(i))
                {
                    Draw.DrawItem(armyOfInvaders[i]);
                }
            }
        }
        public static void EraseItem(List<List<Position>> armyOfInvaders)
        {
            foreach (List<Position> invader in armyOfInvaders)
            {
                foreach (Position part in invader)
                {
                    Console.SetCursorPosition(part.Col, part.Row);
                    Console.Write(' ');
                }
            }
        }
        public static void EraseItem(List<Position> invader)
        {
            foreach (Position part in invader)
            {
                Console.SetCursorPosition(part.Col, part.Row);
                Console.Write(' ');
            }
        }
        public static void DrawShoot()
        {
            for (int Row = 0; Row < Shoot.shoot.GetLength(0); Row++)
            {
                for (int Col = 0; Col < Shoot.shoot.GetLength(1); Col++)
                {
                    if (Shoot.shoot[Row, Col] == 1)
                    {
                        Console.SetCursorPosition(Col, Row);
                        Console.Write("|");
                    }
                }
            }
        }
        public static void EraseShoot()
        {
            for (int Row = 0; Row < Shoot.shoot.GetLength(0); Row++)
            {
                for (int Col = 0; Col < Shoot.shoot.GetLength(1); Col++)
                {
                    if (Row == 0)
                    {
                        Console.SetCursorPosition(Col, Row);
                        Console.Write(" ");
                    }
                    if (Shoot.shoot[Row, Col] == 1)
                    {
                        Console.SetCursorPosition(Col, Row + 1);
                        Console.Write(" ");
                    }
                }
            }
        }
    }
    public class Collision
    {
        public static void InvaderGotShot()
        {
            
            for (int i = 0; i < ArmyOfInvaders.armyOfInvaders.Count; i++)
            {
                for (int j = 0; j < ArmyOfInvaders.armyOfInvaders[i].Count; j++)
                {
                    if (Shoot.shoot[ArmyOfInvaders.armyOfInvaders[i][j].Row, ArmyOfInvaders.armyOfInvaders[i][j].Col] == 1)
                    {
                        if (!ArmyOfInvaders.deadInvaders.Contains(i))
                        {
                            Shoot.shoot[ArmyOfInvaders.armyOfInvaders[i][j].Row,
                                ArmyOfInvaders.armyOfInvaders[i][j].Col] = 0;
                            ArmyOfInvaders.deadInvaders.Add(i);
                            return;
                        }
                    }
                }
            }
        }
    }
    public class ArmyOfInvaders
    {
        public static int invadersColDistance = 9;
        public static int invadersColsCount = 10;
        public static int invadersRowDistance = 4;
        public static int invadersRowsCount = 4;
        public static List<int> deadInvaders = new List<int>(); 
        public static int startArmyOfInvadersPosition = (Settings.maxCols - (ArmyOfInvaders.invadersColDistance * ArmyOfInvaders.invadersColsCount)) / 2 + 5;//5 e shiranata na edin invader
        public static List<List<Position>> armyOfInvaders = new List<List<Position>>();
        public static void InitializeArmyOfInvaders(int moveY = 0, int moveX = 0)
        {
            for (int row = 0; row < invadersRowDistance * invadersRowsCount; row += invadersRowDistance)
            {
                for (int col = 0; col < invadersColDistance * invadersColsCount; col += invadersColDistance)
                {
                    var invader = Invader.InitializeInvader(row + moveY, col + moveX);
                    armyOfInvaders.Add(invader);
                }
            }
        }
    }
    public class Common
    {
        public static int gameSpeed = 1;
    }
