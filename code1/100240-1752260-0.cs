    namespace Battleship
    {
        using System;
        using System.Collections.ObjectModel;
        using System.Drawing;
        using System.Collections.Generic;
        using System.Linq;
     
        public class BSKiller4 : OpponentExtended, IBattleshipOpponent
        {
            public string Name { get { return "BSKiller4"; } }
            public Version Version { get { return this.version; } }
     
            public bool showBoard = false;
     
            Random rand = new Random();
            Version version = new Version(0, 4);
            Size gameSize;
     
            List<Point> nextShots;
            Queue<Point> scanShots;
     
            char[,] board;
     
            private void printBoard()
            {
                Console.WriteLine();
                for (int y = 0; y < this.gameSize.Height; y++)
                {
                    for (int x = 0; x < this.gameSize.Width; x++)
                    {
                        Console.Write(this.board[x, y]);
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
     
            public void NewGame(Size size, TimeSpan timeSpan)
            {
                this.gameSize = size;
                board = new char[size.Width, size.Height];
                this.nextShots = new List<Point>();
                this.scanShots = new Queue<Point>();
                fillScanShots();
                initializeBoard();
            }
     
            private void initializeBoard()
            {
                for (int y = 0; y < this.gameSize.Height; y++)
                {
                    for (int x = 0; x < this.gameSize.Width; x++)
                    {
                        this.board[x, y] = 'O';
                    }
                }
            }
     
            private void fillScanShots()
            {
                int x, y;
                int num = gameSize.Width * gameSize.Height;
                for (int j = 0; j < 3; j++)
                {
                    for (int i = j; i < num; i += 3)
                    {
                        x = i % gameSize.Width;
                        y = i / gameSize.Height;
                        scanShots.Enqueue(new Point(x, y));
                    }
                }
            }
     
            public void PlaceShips(ReadOnlyCollection<Ship> ships)
            {
                foreach (Ship s in ships)
                {
                    s.Place(new Point(
                            rand.Next(this.gameSize.Width),
                            rand.Next(this.gameSize.Height)),
                            (ShipOrientation)rand.Next(2));
                }
            }
     
            public Point GetShot()
            {
                if (showBoard) printBoard();
                Point shot;
     
                shot = findShotRun();
                if (shot.X != -1)
                {
                    return shot;
                }
     
                if (this.nextShots.Count > 0)
                {
                    shot = this.nextShots[0];
                    this.nextShots.RemoveAt(0);
                }
                else
                {
                    shot = this.scanShots.Dequeue();
                }
     
                return shot;
            }
     
            public void ShotHit(Point shot, bool sunk)
            {
                this.board[shot.X, shot.Y] = 'H';
                if (!sunk)
                {
                    addToNextShots(new Point(shot.X - 1, shot.Y));
                    addToNextShots(new Point(shot.X, shot.Y + 1));
                    addToNextShots(new Point(shot.X + 1, shot.Y));
                    addToNextShots(new Point(shot.X, shot.Y - 1));
                }
                else
                {
                    this.nextShots.Clear();
                }
            }
     
     
     
            private Point findShotRun()
            {
                int run_forward_horizontal = 0;
                int run_backward_horizontal = 0;
                int run_forward_vertical = 0;
                int run_backward_vertical = 0;
     
                List<shotPossibilities> possible = new List<shotPossibilities>(5);
     
                // this only works if width = height for the board;
                for (int y = 0; y < this.gameSize.Height; y++)
                {
                    for (int x = 0; x < this.gameSize.Width; x++)
                    {
                        // forward horiz
                        if (this.board[x, y] == 'M')
                        {
                            run_forward_horizontal = 0;
                        }
                        else if (this.board[x, y] == 'O')
                        {
                            if (run_forward_horizontal >= 2)
                            {
                                possible.Add(
                                    new shotPossibilities(
                                        run_forward_horizontal,
                                        new Point(x, y),
                                        true));
                            }
                            else
                            {
                                run_forward_horizontal = 0;
                            }
                        }
                        else
                        {
                            run_forward_horizontal++;
                        }
     
                        // forward vertical
                        if (this.board[y, x] == 'M')
                        {
                            run_forward_vertical = 0;
                        }
                        else if (this.board[y, x] == 'O')
                        {
                            if (run_forward_vertical >= 2)
                            {
                                possible.Add(
                                    new shotPossibilities(
                                        run_forward_vertical,
                                        new Point(y, x),
                                        false));
                            }
                            else
                            {
                                run_forward_vertical = 0;
                            }
                        }
                        else
                        {
                            run_forward_vertical++;
                        }
     
     
                        // backward horiz
                        if (this.board[this.gameSize.Width - x - 1, y] == 'M')
                        {
                            run_backward_horizontal = 0;
                        }
                        else if (this.board[this.gameSize.Width - x - 1, y] == 'O')
                        {
                            if (run_backward_horizontal >= 2)
                            {
                                possible.Add(
                                    new shotPossibilities(
                                        run_backward_horizontal,
                                        new Point(this.gameSize.Width - x - 1, y),
                                        true));
                            }
                            else
                            {
                                run_backward_horizontal = 0;
                            }
                        }
                        else
                        {
                            run_backward_horizontal++;
                        }
     
     
                        // backward vertical
                        if (this.board[y, this.gameSize.Height - x - 1] == 'M')
                        {
                            run_backward_vertical = 0;
                        }
                        else if (this.board[y, this.gameSize.Height - x - 1] == 'O')
                        {
                            if (run_backward_vertical >= 2)
                            {
                                possible.Add(
                                    new shotPossibilities(
                                        run_backward_vertical,
                                        new Point(y, this.gameSize.Height - x - 1),
                                        false));
                            }
                            else
                            {
                                run_backward_vertical = 0;
                            }
                        }
                        else
                        {
                            run_backward_vertical++;
                        }
     
                    }
     
                    run_forward_horizontal = 0;
                    run_backward_horizontal = 0;
                    run_forward_vertical = 0;
                    run_backward_vertical = 0;
                }
                Point shot;
     
                if (possible.Count > 0)
                {
                    shotPossibilities shotp = possible.OrderByDescending(a => a.run).First();
                    //this.nextShots.Clear();
                    shot = shotp.shot;
                    //if (shotp.isHorizontal)
                    //{
                    //    this.nextShots.RemoveAll(p => p.X != shot.X);
                    //}
                    //else
                    //{
                    //    this.nextShots.RemoveAll(p => p.Y != shot.Y);
                    //}
                }
                else
                {
                    shot = new Point(-1, -1);
                }
     
                return shot;
            }
     
            private void addToNextShots(Point p)
            {
                if (!this.nextShots.Contains(p) &&
                    p.X >= 0 &&
                    p.X < this.gameSize.Width &&
                    p.Y >= 0 &&
                    p.Y < this.gameSize.Height)
                {
                    if (this.board[p.X, p.Y] == 'O')
                    {
                        this.nextShots.Add(p);
                    }
                }
            }
     
            public void GameWon()
            {
                this.GameWins++;
            }
     
            public void NewMatch(string opponent)
            {
                System.Threading.Thread.Sleep(5);
                this.rand = new Random(System.Environment.TickCount);
            }
            public void OpponentShot(Point shot) { }
            public void ShotMiss(Point shot)
            {
                this.board[shot.X, shot.Y] = 'M';
            }
            public void GameLost()
            {
                if (showBoard) Console.WriteLine("-----Game Over-----");
            }
            public void MatchOver() { }
        }
     
     
        public class OpponentExtended
        {
            public int GameWins { get; set; }
            public int MatchWins { get; set; }
            public OpponentExtended() { }
        }
     
        public class shotPossibilities
        {
            public shotPossibilities(int r, Point s, bool h)
            {
                this.run = r;
                this.shot = s;
                this.isHorizontal = h;
            }
            public int run { get; set; }
            public Point shot { get; set; }
            public bool isHorizontal { get; set; }
        }
    }
