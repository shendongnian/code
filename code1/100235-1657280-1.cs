    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    
    namespace Battleship.ShuggyCoUk
    {
        class Simple : IBattleshipOpponent
        {
            BoardView<OpponentsBoardState> opponentsBoard = new BoardView<OpponentsBoardState>(new Size(10,10));
            Rand rand = new Rand();
            int gridOddEven;
            Size size;
    
            public string Name { get { return "Simple"; } }
    
            public Version Version { get { return new Version(2, 1); }}
    
            public void NewMatch(string opponent) {}
    
            public void NewGame(System.Drawing.Size size, TimeSpan timeSpan)
            {
                this.size = size;
                this.opponentsBoard = new BoardView<OpponentsBoardState>(size);
                this.gridOddEven = rand.Pick(new[] { 0, 1 });
            }
    
            public void PlaceShips(System.Collections.ObjectModel.ReadOnlyCollection<Ship> ships)
            {
                BoardView<bool> board = new BoardView<bool>(size);
                var AllOrientations = new[] {
                    ShipOrientation.Horizontal,
                    ShipOrientation.Vertical };
    
                foreach (var ship in ships)
                {
                    int avoidTouching = 3;
                    while (!ship.IsPlaced)
                    {
                        var l = rand.Pick(board.Select(c => c.Location));
                        var o = rand.Pick(AllOrientations);
                        if (ship.IsLegal(ships, size, l, o))
                        {
                            if (ship.IsTouching(ships, l, o)&& --avoidTouching > 0)
                                continue;
                            ship.Place(l, o);
                        }
                    }
                }
            }
            protected virtual Point PickWhenNoTargets()
            {
                return rand.PickBias(x => x.Bias,
                    opponentsBoard
                    // nothing 1 in size
                    .Where(c => (c.Location.X + c.Location.Y) % 2 == gridOddEven)
                    .Where(c => c.Data == OpponentsBoardState.Unknown))
                    .Location;
            }
    
            private int SumLine(Cell<OpponentsBoardState> c, int acc)
            {
                if (acc >= 0)
                    return acc;
                if (c.Data == OpponentsBoardState.Hit)
                    return acc - 1;
                return -acc;
            }
    
            public System.Drawing.Point GetShot()
            {
                var targets = opponentsBoard
                    .Where(c => c.Data == OpponentsBoardState.Hit)
                    .SelectMany(c => c.Neighbours())
                    .Where(c => c.Data == OpponentsBoardState.Unknown)
                    .ToList();
                if (targets.Count > 1)
                {
                    var lines = targets.Where(
                        x => x.FoldAll(-1, SumLine).Select(r => Math.Abs(r) - 1).Max() > 1).ToList();
                    if (lines.Count > 0)
                        targets = lines;
                }
                var target = targets.RandomOrDefault(rand);
                if (target == null)
                    return PickWhenNoTargets();
                return target.Location;
            }
    
            public void OpponentShot(System.Drawing.Point shot)
            {
            }
    
            public void ShotHit(Point shot, bool sunk)
            {
                opponentsBoard[shot] = OpponentsBoardState.Hit;
                Debug(shot, sunk);
            }
    
            public void ShotMiss(Point shot)
            {
                opponentsBoard[shot] = OpponentsBoardState.Miss;
                Debug(shot, false);
            }
    
            public const bool DebugEnabled = false;
    
            public void Debug(Point shot, bool sunk)
            {
                if (!DebugEnabled)
                    return;
                opponentsBoard.WriteAsGrid(
                    Console.Out,
                    x =>
                    {
                        string t;
                        switch (x.Data)
                        {
                            case OpponentsBoardState.Unknown:
                                return " ";
                            case OpponentsBoardState.Miss:
                                t = "m";
                                break;
                            case OpponentsBoardState.MustBeEmpty:
                                t = "/";
                                break;
                            case OpponentsBoardState.Hit:
                                t = "x";
                                break;
                            default:
                                t = "?";
                                break;
                        }
                        if (x.Location == shot)
                            t = t.ToUpper();
                        return t;
                    });
                if (sunk)
                    Console.WriteLine("sunk!");
                Console.ReadLine();
            }
    
            public void GameWon()
            {
            }
    
            public void GameLost()
            {
            }
    
            public void MatchOver()
            {
            }
        }
    }
