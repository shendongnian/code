    namespace Battleship
    {
        using System;
        using System.Collections.Generic;
        using System.Drawing;
        using System.Linq;
    
        public class BP7 : IBattleshipOpponent
        {
            public string Name { get { return "BP7"; } }
            public Version Version { get { return this.version; } }
    
            Random rand = new Random();
            Version version = new Version(0, 7);
            Size gameSize;
            List<Point> scanShots;
            List<NextShot> nextShots;
            int wins, losses;
            int totalWins = 0;
            int totalLosses = 0;
            int maxWins = 0;
            int maxLosses = 0;
            int matchWins = 0;
            int matchLosses = 0;
    
            public enum Direction { VERTICAL = -1, UNKNOWN = 0, HORIZONTAL = 1 };
            Direction hitDirection, lastShotDirection;
    
            enum ShotResult { UNKNOWN, MISS, HIT };
            ShotResult[,] board;
    
            public struct NextShot
            {
                public Point point;
                public Direction direction;
                public NextShot(Point p, Direction d)
                {
                    point = p;
                    direction = d;
                }
            }
    
            public struct ScanShot
            {
                public Point point;
                public int openSpaces;
                public ScanShot(Point p, int o)
                {
                    point = p;
                    openSpaces = o;
                }
            }
    
            public void NewGame(Size size, TimeSpan timeSpan)
            {
                this.gameSize = size;
                scanShots = new List<Point>();
                nextShots = new List<NextShot>();
                fillScanShots();
                hitDirection = Direction.UNKNOWN;
                board = new ShotResult[size.Width, size.Height];
            }
    
            private void fillScanShots()
            {
                int x;
                for (x = 0; x < gameSize.Width - 1; x++)
                {
                    scanShots.Add(new Point(x, x));
                }
    
                if (gameSize.Width == 10)
                {
                    for (x = 0; x < 3; x++)
                    {
                        scanShots.Add(new Point(9 - x, x));
                        scanShots.Add(new Point(x, 9 - x));
                    }
                }
            }
    
            public void PlaceShips(System.Collections.ObjectModel.ReadOnlyCollection<Ship> ships)
            {
                foreach (Ship s in ships)
                {
                    s.Place(
                        new Point(
                            rand.Next(this.gameSize.Width),
                            rand.Next(this.gameSize.Height)),
                        (ShipOrientation)rand.Next(2));
                }
            }
    
            public Point GetShot()
            {
                Point shot;
    
                if (this.nextShots.Count > 0)
                {
                    if (hitDirection != Direction.UNKNOWN)
                    {
                        if (hitDirection == Direction.HORIZONTAL)
                        {
                            this.nextShots = this.nextShots.OrderByDescending(x => x.direction).ToList();
                        }
                        else
                        {
                            this.nextShots = this.nextShots.OrderBy(x => x.direction).ToList();
                        }
                    }
    
                    shot = this.nextShots.First().point;
                    lastShotDirection = this.nextShots.First().direction;
                    this.nextShots.RemoveAt(0);
                    return shot;
                }
    
                List<ScanShot> scanShots = new List<ScanShot>();
                for (int x = 0; x < gameSize.Width; x++)
                {
                    for (int y = 0; y < gameSize.Height; y++)
                    {
                        if (board[x, y] == ShotResult.UNKNOWN)
                        {
                            scanShots.Add(new ScanShot(new Point(x, y), OpenSpaces(x, y)));
                        }
                    }
                }
                scanShots = scanShots.OrderByDescending(x => x.openSpaces).ToList();
                int maxOpenSpaces = scanShots.FirstOrDefault().openSpaces;
    
                List<ScanShot> scanShots2 = new List<ScanShot>();
                scanShots2 = scanShots.Where(x => x.openSpaces == maxOpenSpaces).ToList();
                shot = scanShots2[rand.Next(scanShots2.Count())].point;
    
                return shot;
            }
    
            int OpenSpaces(int x, int y)
            {
                int ctr = 0;
                Point p;
    
                // spaces to the left
                p = new Point(x - 1, y);
                while (p.X >= 0 && board[p.X, p.Y] == ShotResult.UNKNOWN)
                {
                    ctr++;
                    p.X--;
                }
    
                // spaces to the right
                p = new Point(x + 1, y);
                while (p.X < gameSize.Width && board[p.X, p.Y] == ShotResult.UNKNOWN)
                {
                    ctr++;
                    p.X++;
                }
    
                // spaces to the top
                p = new Point(x, y - 1);
                while (p.Y >= 0 && board[p.X, p.Y] == ShotResult.UNKNOWN)
                {
                    ctr++;
                    p.Y--;
                }
    
                // spaces to the bottom
                p = new Point(x, y + 1);
                while (p.Y < gameSize.Height && board[p.X, p.Y] == ShotResult.UNKNOWN)
                {
                    ctr++;
                    p.Y++;
                }
    
                return ctr;
            }
    
            public void NewMatch(string opponenet)
            {
                wins = 0;
                losses = 0;
            }
    
            public void OpponentShot(Point shot) { }
    
            public void ShotHit(Point shot, bool sunk)
            {
                board[shot.X, shot.Y] = ShotResult.HIT;
    
                if (!sunk)
                {
                    hitDirection = lastShotDirection;
                    if (shot.X != 0)
                    {
                        this.nextShots.Add(new NextShot(new Point(shot.X - 1, shot.Y), Direction.HORIZONTAL));
                    }
    
                    if (shot.Y != 0)
                    {
                        this.nextShots.Add(new NextShot(new Point(shot.X, shot.Y - 1), Direction.VERTICAL));
                    }
    
                    if (shot.X != this.gameSize.Width - 1)
                    {
                        this.nextShots.Add(new NextShot(new Point(shot.X + 1, shot.Y), Direction.HORIZONTAL));
                    }
    
                    if (shot.Y != this.gameSize.Height - 1)
                    {
                        this.nextShots.Add(new NextShot(new Point(shot.X, shot.Y + 1), Direction.VERTICAL));
                    }
                }
                else
                {
                    hitDirection = Direction.UNKNOWN;
                    this.nextShots.Clear();     // so now this works like gangbusters ?!?!?!?!?!?!?!?!?
                }
            }
    
            public void ShotMiss(Point shot)
            {
                board[shot.X, shot.Y] = ShotResult.MISS;
            }
    
            public void GameWon()
            {
                wins++;
            }
    
            public void GameLost()
            {
                losses++;
            }
    
            public void MatchOver()
            {
                if (wins > maxWins)
                {
                    maxWins = wins;
                }
    
                if (losses > maxLosses)
                {
                    maxLosses = losses;
                }
    
                totalWins += wins;
                totalLosses += losses;
    
                if (wins >= 51)
                {
                    matchWins++;
                }
                else
                {
                    matchLosses++;
                }
            }
    
            public void FinalStats()
            {
                Console.WriteLine("Games won: " + totalWins.ToString());
                Console.WriteLine("Games lost: " + totalLosses.ToString());
                Console.WriteLine("Game winning percentage: " + (totalWins * 1.0 / (totalWins + totalLosses)).ToString("P"));
                Console.WriteLine("Game losing percentage: " + (totalLosses * 1.0 / (totalWins + totalLosses)).ToString("P"));
                Console.WriteLine();
                Console.WriteLine("Matches won: " + matchWins.ToString());
                Console.WriteLine("Matches lost: " + matchLosses.ToString());
                Console.WriteLine("Match winning percentage: " + (matchWins * 1.0 / (matchWins + matchLosses)).ToString("P"));
                Console.WriteLine("Match losing percentage: " + (matchLosses * 1.0 / (matchWins + matchLosses)).ToString("P"));
                Console.WriteLine("Match games won high: " + maxWins.ToString());
                Console.WriteLine("Match games lost high: " + maxLosses.ToString());
                Console.WriteLine();
            }
        }
    }
