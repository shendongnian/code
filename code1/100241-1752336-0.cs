    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    
    namespace Battleship
    {
        // The Empire of Japan surrendered on the deck of the USS Missouri on Sept. 2, 1945
        public class USSMissouri : IBattleshipOpponent
        {
            public String  Name    { get { return name; } }
            public Version Version { get { return ver;  } }
           
    #region IBattleship Interface
            // IBattleship::NewGame
            public void NewGame(Size gameSize, TimeSpan timeSpan)
            {
                size      = gameSize;
                shotBoard = new ShotBoard(size);
                attackVector = new Stack<Attack>();
            }
    
            // IBattleship::PlaceShips
            public void PlaceShips(ReadOnlyCollection<Ship> ships)
            {
                HunterBoard board;
                targetBoards = new List<HunterBoard>();
                shotBoard    = new ShotBoard(size);
                foreach (Ship s in ships)
                {
                    board = new HunterBoard(this, size, s);
                    targetBoards.Add(board);
    
                    // REWRITE: to ensure valid board placement.
                    s.Place(
                        new Point(
                            rand.Next(size.Width),
                            rand.Next(size.Height)),
                        (ShipOrientation)rand.Next(2));
                }
            }
    
            // IBattleship::GetShot
            public Point GetShot()
            {
                Point p = new Point();
    
                if (attackVector.Count() > 0)
                {
                    p = ExtendShot();
                    return p;
                }
    
                // Contemplate a shot at every-single point, and measure how effective it would be.
                Board potential = new Board(size);
                for(p.Y=0; p.Y<size.Height; ++p.Y)
                {
                    for(p.X=0; p.X<size.Width; ++p.X)
                    {
                        if (shotBoard.ShotAt(p))
                        {
                            potential[p] = 0;
                            continue;
                        }
    
                        foreach(HunterBoard b in targetBoards)
                        {
                            potential[p] += b.GetWeightAt(p);
                        }
                    }
                }
    
                // Okay, we have the shot potential of the board.
                // Lets pick a weighted-random spot.
                Point shot;
                shot = potential.GetWeightedRandom(rand.NextDouble());
                
                shotBoard[shot] = Shot.Unresolved;
                
                return shot;
            }
    
            public Point ExtendShot()
            {
                // Lets consider North, South, East, and West of the current shot.
                // and measure the potential of each
                Attack attack = attackVector.Peek();
    
                Board potential = new Board(size);
    
                Point[] points = attack.GetNextTargets();
                foreach(Point p in points)
                {
                    if (shotBoard.ShotAt(p))
                    {
                        potential[p] = 0;
                        continue;
                    }
    
                    foreach(HunterBoard b in targetBoards)
                    {
                        potential[p] += b.GetWeightAt(p);
                    }
                }
    
                Point shot = potential.GetBestShot();
                shotBoard[shot] = Shot.Unresolved;
                return shot;
            }
    
            // IBattleship::NewMatch
            public void NewMatch(string opponent)
            {
            }
            public void OpponentShot(Point shot)
            {
            }
            public void ShotHit(Point shot, bool sunk)
            {
                shotBoard[shot] = Shot.Hit;
    
                if (!sunk)
                {
                    if (attackVector.Count == 0) // This is a first hit, open an attackVector
                    {   
                        attackVector.Push(new Attack(this, shot));
                    }
                    else
                    {
                        attackVector.Peek().AddHit(shot);    // Add a hit to our current attack.
                    }
                }
    
                // What if it is sunk?  Close the top attack, which we've been pursuing.
                if (sunk)
                {
                    if (attackVector.Count > 0)
                    {
                        attackVector.Pop();
                    }
                }
            }
            public void ShotMiss(Point shot)
            {
                shotBoard[shot] = Shot.Miss;
    
                foreach(HunterBoard b in targetBoards)
                {
                    b.ShotMiss(shot);  // Update the potential map.
                }
            }
            public void GameWon()
            {
                Trace.WriteLine  ("I won the game!");
            }
            public void GameLost()
            {
                Trace.WriteLine  ("I lost the game!");
            }
            public void MatchOver()
            {
                Trace.WriteLine("This match is over.");
            }
    
    #endregion 
    
            public ShotBoard theShotBoard
            {
                get { return shotBoard; }
            }
            public Size theBoardSize
            {
                get { return size; }
            }
    
            private Random rand = new Random();
            private Version ver = new Version(6, 3); // USS Missouri is BB-63, hence version 6.3
            private String name = "USS Missouri (abelenky@alum.mit.edu)";
            private Size size;
            private List<HunterBoard> targetBoards;
            private ShotBoard shotBoard;
            private Stack<Attack> attackVector;
        }
    
        // An Attack is the data on the ship we are currently working on sinking.
        // It consists of a set of points, horizontal and vertical, from a central point.
        // And can be extended in any direction.
        public class Attack
        {
            public Attack(USSMissouri root, Point p)
            {
                Player = root;
                hit = p;
                horzExtent = new Extent(p.X, p.X);
                vertExtent = new Extent(p.Y, p.Y);
            }
    
            public Extent HorizontalExtent
            {
                get { return horzExtent; }
            }
            public Extent VerticalExtent
            {
                get { return vertExtent; }
            }
            public Point  FirstHit
            {
                get { return hit; }
            }
    
            public void AddHit(Point p)
            {
                if (hit.X == p.X) // New hit in the vertical direction
                {
                    vertExtent.Min = Math.Min(vertExtent.Min, p.Y);
                    vertExtent.Max = Math.Max(vertExtent.Max, p.Y);
                }
                else if (hit.Y == p.Y)
                {
                    horzExtent.Min = Math.Min(horzExtent.Min, p.X);
                    horzExtent.Max = Math.Max(horzExtent.Max, p.X);
                }
            }
            public Point[] GetNextTargets() 
            {
                List<Point> bors = new List<Point>();
    
                Point p;
    
                p = new Point(hit.X, vertExtent.Min-1);
                while (p.Y >= 0 && Player.theShotBoard[p] == Shot.Hit)
                {
                    if (Player.theShotBoard[p] == Shot.Miss)
                    {
                        break; // Don't add p to the List 'bors.  
                    }
                    --p.Y;
                }
                if (p.Y >= 0 && Player.theShotBoard[p] == Shot.None) // Add next-target only if there is no shot here yet.
                {
                    bors.Add(p);
                }
    
                //-------------------
        
                p = new Point(hit.X, vertExtent.Max+1);
                while (p.Y < Player.theBoardSize.Height && Player.theShotBoard[p] == Shot.Hit)
                {
                    if (Player.theShotBoard[p] == Shot.Miss)
                    {
                        break; // Don't add p to the List 'bors.  
                    }
                    ++p.Y;
                }
                if (p.Y < Player.theBoardSize.Height && Player.theShotBoard[p] == Shot.None)
                {
                    bors.Add(p);
                }
    
                //-------------------
        
                p = new Point(horzExtent.Min-1, hit.Y);
                while (p.X >= 0 && Player.theShotBoard[p] == Shot.Hit)
                {
                    if (Player.theShotBoard[p] == Shot.Miss)
                    {
                        break; // Don't add p to the List 'bors.  
                    }
                    --p.X;
                }
                if (p.X >= 0 && Player.theShotBoard[p] == Shot.None)
                {
                    bors.Add(p);
                }
    
                //-------------------
        
                p = new Point(horzExtent.Max+1, hit.Y);
                while (p.X < Player.theBoardSize.Width && Player.theShotBoard[p] == Shot.Hit)
                {
                    if (Player.theShotBoard[p] == Shot.Miss)
                    {
                        break; // Don't add p to the List 'bors.  
                    }
                    ++p.X;
                }
                if (p.X < Player.theBoardSize.Width && Player.theShotBoard[p] == Shot.None)
                {
                    bors.Add(p);
                }
    
                return bors.ToArray();
            }
    
            private Point hit; 
            private Extent horzExtent;
            private Extent vertExtent;
            private USSMissouri Player;
        }
    
        public struct Extent
        {
            public Extent(Int32 min, Int32 max)
            {
                Min = min;
                Max = max;
            }
            public Int32 Min;
            public Int32 Max;
        }
    
        public class Board  // The potential-Board, which measures the full potential of each square.
        {
            // A Board is the status of many things.
            public Board(Size boardsize)
            {
                size = boardsize;
                grid = new int[size.Width , size.Height];
                Array.Clear(grid,0,size.Width*size.Height);
            }
            
            public int this[int c,int r]
            {
                get { return grid[c,r];  }
                set { grid[c,r] = value; }
            }
            public int this[Point p]
            {
                get { return grid[p.X, p.Y];  }
                set { grid[p.X, p.Y] = value; }
            }
    
            public Point GetWeightedRandom(double r)
            {
                Int32 sum = 0;
                foreach(Int32 i in grid)
                {
                    sum += i;
                }
    
                Int32 index = (Int32)(r*sum);
                
                Int32 x=0, y=0;
                for(y=0; y<size.Height; ++y)
                {
                    for(x=0; x<size.Width; ++x)
                    {
                        if (grid[x,y] == 0) continue; // Skip any zero-cells
                        index -= grid[x,y];
                        if (index < 0) break;
                    }
                    if (index < 0) break;
                }
    
                if (x == 10 || y == 10)
                    throw new Exception("WTF");
    
                return new Point(x,y);
            }
    
            public Point GetBestShot()
            {
                int max=grid[0,0];
                for(int y=0; y<size.Height; ++y)
                {
                    for (int x=0; x<size.Width; ++x)
                    {
                        max = (grid[x,y] > max)? grid[x,y] : max;
                    }
                }
    
                for(int y=0; y<size.Height; ++y)
                {
                    for (int x=0; x<size.Width; ++x)
                    {
                        if (grid[x,y] == max)
                        {
                            return new Point(x,y);
                        }
                    }
                }
                return new Point(0,0);
            }
    
            public bool IsZero()
            {
                foreach(Int32 p in grid)
                {
                    if (p > 0)
                    {
                        return false;
                    }
                }
                return true;
            }
    
            public override String ToString()
            {
                String output = "";
                String horzDiv = "   +----+----+----+----+----+----+----+----+----+----+\n";
                String disp;
                int x,y;
    
                output += "      A    B    C    D    E    F    G    H    I    J    \n" + horzDiv;
                   
                for(y=0; y<size.Height; ++y)
                {
                    output += String.Format("{0} ", y+1).PadLeft(3);
                    for(x=0; x<size.Width; ++x)
                    {
                        switch(grid[x,y])
                        {
                            case (int)Shot.None:       disp = "";  break;
                            case (int)Shot.Hit:        disp = "#"; break;
                            case (int)Shot.Miss:       disp = "."; break;
                            case (int)Shot.Unresolved: disp = "?"; break;
                            default:                   disp = "!"; break;
                        }
            
                        output += String.Format("| {0} ", disp.PadLeft(2));
                    }
                    output += "|\n" + horzDiv;
                }
     
                return output;
            }
    
            protected Int32[,] grid;
            protected Size     size;
        }
    
        public class HunterBoard
        {
            public HunterBoard(USSMissouri root, Size boardsize, Ship target)
            {
                size = boardsize;
                grid = new int[size.Width , size.Height];
                Array.Clear(grid,0,size.Width*size.Height);
    
                Player = root;
                Target = target;
                Initialize();
            }
    
            public void Initialize()
            {
                int x, y, i;
    
                for(y=0; y<size.Height; ++y)
                {
                    for(x=0; x<size.Width - Target.Length+1; ++x)
                    {
                        for(i=0; i<Target.Length; ++i)
                        {
                            grid[x+i,y]++;
                        }
                    }
                }
    
                for(y=0; y<size.Height-Target.Length+1; ++y)
                {
                    for(x=0; x<size.Width; ++x)
                    {
                        for(i=0; i<Target.Length; ++i)
                        {
                            grid[x,y+i]++;
                        }
                    }
                }
            }
    
            public int this[int c,int r]
            {
                get { return grid[c,r];  }
                set { grid[c,r] = value; }
            }
            public int this[Point p]
            {
                get { return grid[p.X, p.Y];  }
                set { grid[p.X, p.Y] = value; }
            }
    
            public void ShotMiss(Point p)
            {
                int x,y;
                int min, max;
    
                min = Math.Max(p.X-Target.Length+1, 0);
                max = Math.Min(p.X, size.Width-Target.Length);
                for(x=min; x<=max; ++x)
                {
                    DecrementRow(p.Y, x, x+Target.Length-1);
                }
    
                min = Math.Max(p.Y-Target.Length+1, 0);
                max = Math.Min(p.Y, size.Height-Target.Length);
                for(y=min; y<=max; ++y)
                {
                    DecrementColumn(p.X, y, y+Target.Length-1);
                } 
    
                grid[p.X, p.Y] = 0;
            }
    
            public void ShotHit(Point p)
            {
            }
    
            public override String ToString()
            {
                String output = String.Format("Target size is {0}\n", Target.Length);
                String horzDiv = "   +----+----+----+----+----+----+----+----+----+----+\n";
                int x,y;
    
                output += "      A    B    C    D    E    F    G    H    I    J    \n" + horzDiv;
                for(y=0; y<size.Height; ++y)
                {
                    output += String.Format("{0} ", y+1).PadLeft(3);
                    for(x=0; x<size.Width; ++x)
                    {
                        output += String.Format("| {0} ", grid[x,y].ToString().PadLeft(2));
                    }
                    output += "|\n" + horzDiv;
                }
                return output;
            }
    
            // If we shoot at point P, how does that affect the potential of the board?
            public Int32 GetWeightAt(Point p)
            {
                int x,y;
                int potential = 0;
                int min, max;
                
                min = Math.Max(p.X-Target.Length+1, 0);
                max = Math.Min(p.X, size.Width-Target.Length);
                for(x=min; x<=max; ++x)
                {
                    if (Player.theShotBoard.isMissInRow(p.Y, x, x+Target.Length-1) == false)
                    {
                        ++potential;
                    }
                }
    
                min = Math.Max(p.Y-Target.Length+1, 0);
                max = Math.Min(p.Y, size.Height-Target.Length);
                for(y=min; y<=max; ++y)
                {
                    if (Player.theShotBoard.isMissInColumn(p.X, y, y+Target.Length-1) == false)
                    {
                        ++potential;
                    }
                } 
    
                return potential;
            }
    
            public void DecrementRow(int row, int rangeA, int rangeB)
            {
                int x;
                for(x=rangeA; x<=rangeB; ++x)
                {
                    grid[x,row] = (grid[x,row]==0)? 0 : grid[x,row]-1;
                }
            }
            public void DecrementColumn(int col, int rangeA, int rangeB)
            {
                int y;
                for(y=rangeA; y<=rangeB; ++y)
                {
                    grid[col,y] = (grid[col,y]==0)? 0 : grid[col,y]-1;
                }
            }
         
            private Ship Target = null;
            private USSMissouri Player;
            private Int32[,] grid;
            private Size     size;
        }
    
        public enum Shot
        {
            None = 0,
            Hit = 1,
            Miss = 2,
            Unresolved = 3
        };
    
        public class ShotBoard
        {
            public ShotBoard(Size boardsize)
            {
                size = boardsize;
                grid = new Shot[size.Width , size.Height];
    
                for(int y=0; y<size.Height; ++y)
                {
                    for(int x=0; x<size.Width; ++x)
                    {
                        grid[x,y] = Shot.None;
                    }
                }
            }
            
            public Shot this[int c,int r]
            {
                get { return grid[c,r];  }
                set { grid[c,r] = value; }
            }
            public Shot this[Point p]
            {
                get { return grid[p.X, p.Y];  }
                set { grid[p.X, p.Y] = value; }
            }
            
            public override String ToString()
            {
                String output = "";
                String horzDiv = "   +----+----+----+----+----+----+----+----+----+----+\n";
                String disp;
                int x,y;
    
                output += "      A    B    C    D    E    F    G    H    I    J    \n" + horzDiv;
                   
                for(y=0; y<size.Height; ++y)
                {
                    output += String.Format("{0} ", y+1).PadLeft(3);
                    for(x=0; x<size.Width; ++x)
                    {
                        switch(grid[x,y])
                        {
                            case Shot.None:       disp = "";  break;
                            case Shot.Hit:        disp = "#"; break;
                            case Shot.Miss:       disp = "."; break;
                            case Shot.Unresolved: disp = "?"; break;
                            default:              disp = "!"; break;
                        }
            
                        output += String.Format("| {0} ", disp.PadLeft(2));
                    }
                    output += "|\n" + horzDiv;
                }
                return output;
            }
    
            // Functions to find shots on the board, at a specific point, or in a row or column, within a range
            public bool ShotAt(Point p)
            {
                return !(this[p]==Shot.None);
            }
            public bool isMissInColumn(int col, int rangeA, int rangeB)
            {
                for(int y=rangeA; y<=rangeB; ++y)
                {
                    if (grid[col,y] == Shot.Miss)
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool isMissInRow(int row, int rangeA, int rangeB)
            {
                for(int x=rangeA; x<=rangeB; ++x)
                {
                    if (grid[x,row] == Shot.Miss)
                    {
                        return true;
                    }
                }
                return false;
            }
            protected Shot[,] grid;
            protected Size     size;
        }
    }
