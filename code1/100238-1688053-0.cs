    namespace Battleship
    {
        using System;
        using System.Collections.ObjectModel;
        using System.Drawing;
        using System.Collections.Generic;
        using System.Linq;
        public class AgentSmith : IBattleshipOpponent
        {        
            public string Name { get { return "Agent Smith"; } }
            public Version Version { get { return this.version; } }
            private Random rand = new Random();
            private Version version = new Version(2, 1);
            private Size gameSize;
            private enum Direction { Up, Down, Left, Right }
            private int MissCount;
            private Point?[] EndPoints = new Point?[2];
            private LinkedList<Point> HitShots = new LinkedList<Point>();
            private LinkedList<Point> Shots = new LinkedList<Point>();
            private List<Point> PatternShots = new List<Point>();
            private Direction ShotDirection = Direction.Up;
            private void NullOutTarget()
            {
                EndPoints = new Point?[2];
                MissCount = 0;
            }
            private void SetupPattern()
            {
                for (int y = 0; y < gameSize.Height; y++)
                    for (int x = 0; x < gameSize.Width; x++)
                        if ((x + y) % 2 == 0) PatternShots.Add(new Point(x, y));
            }
            private bool InvalidShot(Point p)
            {
                bool InvalidShot = (Shots.Where(s => s.X == p.X && s.Y == p.Y).Any());
                if (p.X < 0 | p.Y<0) InvalidShot = true;
                if (p.X >= gameSize.Width | p.Y >= gameSize.Height) InvalidShot = true;
                return InvalidShot;
            }
            private Point FireDirectedShot(Direction? direction, Point p)
            {
                ShotDirection = (Direction)direction;
                switch (ShotDirection)
                {
                    case Direction.Up: p.Y--; break;
                    case Direction.Down: p.Y++; break;
                    case Direction.Left: p.X--; break;
                    case Direction.Right: p.X++; break;
                }
                return p;
            }
            private Point FireAroundPoint(Point p)
            {
                if (!InvalidShot(FireDirectedShot(ShotDirection,p)))
                    return FireDirectedShot(ShotDirection, p);
                Point testShot = FireDirectedShot(Direction.Left, p);
                if (InvalidShot(testShot)) { testShot = FireDirectedShot(Direction.Right, p); }
                if (InvalidShot(testShot)) { testShot = FireDirectedShot(Direction.Up, p); }
                if (InvalidShot(testShot)) { testShot = FireDirectedShot(Direction.Down, p); }
                return testShot;
            }
            private Point FireRandomShot()
            {
                Point p;
                do
                {
                    if (PatternShots.Count > 0)
                        PatternShots.Remove(p = PatternShots[rand.Next(PatternShots.Count)]);
                    else do
                        {
                            p = FireAroundPoint(HitShots.First());
                            if (InvalidShot(p)) HitShots.RemoveFirst();
                        } while (InvalidShot(p) & HitShots.Count > 0);
                }
                while (InvalidShot(p));
                return p;
            }
            private Point FireTargettedShot()
            {
                Point p;
                do
                {
                    p = FireAroundPoint(new Point(EndPoints[1].Value.X, EndPoints[1].Value.Y));
                    if (InvalidShot(p) & EndPoints[1] != EndPoints[0])
                        EndPoints[1] = EndPoints[0];
                    else if (InvalidShot(p)) NullOutTarget();
                } while (InvalidShot(p) & EndPoints[1] != null);
                if (InvalidShot(p)) p = FireRandomShot();
                return p;
            }
            private void ResetVars()
            {
                Shots.Clear();
                HitShots.Clear();
                PatternShots.Clear();
                MissCount = 0;
            }
            public void NewGame(Size size, TimeSpan timeSpan)
            {
                gameSize = size;
                ResetVars();
                SetupPattern();
            }
            public void PlaceShips(ReadOnlyCollection<Ship> ships)
            {
                foreach (Ship s in ships)
                    s.Place(new Point(rand.Next(this.gameSize.Width), rand.Next(this.gameSize.Height)), (ShipOrientation)rand.Next(2));
            }
            public Point GetShot()
            {
                if (EndPoints[1] != null) Shots.AddLast(FireTargettedShot());
                else Shots.AddLast(FireRandomShot());
                return Shots.Last();
            }
            public void ShotHit(Point shot, bool sunk)
            {            
                HitShots.AddLast(shot);
                MissCount = 0;
                EndPoints[1] = shot;
                if (EndPoints[0] == null) EndPoints[0] = shot;
                if (sunk) NullOutTarget();
            }
            public void ShotMiss(Point shot)
            {
                if (++MissCount == 6) NullOutTarget();
            }
            public void GameWon() { }
            public void GameLost() { }
            public void NewMatch(string opponent) { }
            public void OpponentShot(Point shot) { }
            public void MatchOver() { }
        }
    }
