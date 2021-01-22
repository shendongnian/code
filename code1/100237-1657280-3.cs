    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.IO;
    using System.Collections.ObjectModel;
    
    namespace Battleship.ShuggyCoUk
    {
        public class Simple : IBattleshipOpponent
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
    
            #region Library code
            enum OpponentsBoardState
            {
                Unknown = 0,
                Miss,
                MustBeEmpty,
                Hit,
            }
    
            public enum Compass
            {
                North, East, South, West
            }
    
            class Cell<T>
            {
                private readonly BoardView<T> view;
                public readonly int X;
                public readonly int Y;
                public T Data;
                public double Bias { get; set; }
    
                public Cell(BoardView<T> view, int x, int y)
                {
                    this.view = view; this.X = x; this.Y = y; this.Bias = 1.0;
                }
    
                public Point Location
                {
                    get { return new Point(X, Y); }
                }
    
                public IEnumerable<U> FoldAll<U>(U acc, Func<Cell<T>, U, U> trip)
                {
                    return new[] { Compass.North, Compass.East, Compass.South, Compass.West }
                        .Select(x => FoldLine(x, acc, trip));
                }
    
                public U FoldLine<U>(Compass direction, U acc, Func<Cell<T>, U, U> trip)
                {
                    var cell = this;
                    while (true)
                    {
                        switch (direction)
                        {
                            case Compass.North:
                                cell = cell.North; break;
                            case Compass.East:
                                cell = cell.East; break;
                            case Compass.South:
                                cell = cell.South; break;
                            case Compass.West:
                                cell = cell.West; break;
                        }
                        if (cell == null)
                            return acc;
                        acc = trip(cell, acc);
                    }
                }
    
                public Cell<T> North
                {
                    get { return view.SafeLookup(X, Y - 1); }
                }
    
                public Cell<T> South
                {
                    get { return view.SafeLookup(X, Y + 1); }
                }
    
                public Cell<T> East
                {
                    get { return view.SafeLookup(X + 1, Y); }
                }
    
                public Cell<T> West
                {
                    get { return view.SafeLookup(X - 1, Y); }
                }
    
                public IEnumerable<Cell<T>> Neighbours()
                {
                    if (North != null)
                        yield return North;
                    if (South != null)
                        yield return South;
                    if (East != null)
                        yield return East;
                    if (West != null)
                        yield return West;
                }
            }
    
            class BoardView<T> : IEnumerable<Cell<T>>
            {
                public readonly Size Size;
                private readonly int Columns;
                private readonly int Rows;
    
                private Cell<T>[] history;
    
                public BoardView(Size size)
                {
                    this.Size = size;
                    Columns = size.Width;
                    Rows = size.Height;
                    this.history = new Cell<T>[Columns * Rows];
                    for (int y = 0; y < Rows; y++)
                    {
                        for (int x = 0; x < Rows; x++)
                            history[x + y * Columns] = new Cell<T>(this, x, y);
                    }
                }
    
                public T this[int x, int y]
                {
                    get { return history[x + y * Columns].Data; }
                    set { history[x + y * Columns].Data = value; }
                }
    
                public T this[Point p]
                {
                    get { return history[SafeCalc(p.X, p.Y, true)].Data; }
                    set { this.history[SafeCalc(p.X, p.Y, true)].Data = value; }
                }
    
                private int SafeCalc(int x, int y, bool throwIfIllegal)
                {
                    if (x < 0 || y < 0 || x >= Columns || y >= Rows)
                    {
                        if (throwIfIllegal)
                            throw new ArgumentOutOfRangeException("[" + x + "," + y + "]");
                        else
                            return -1;
                    }
                    return x + y * Columns;
                }
    
                public void Set(T data)
                {
                    foreach (var cell in this.history)
                        cell.Data = data;
                }
    
                public Cell<T> SafeLookup(int x, int y)
                {
                    int index = SafeCalc(x, y, false);
                    if (index < 0)
                        return null;
                    return history[index];
                }
    
                #region IEnumerable<Cell<T>> Members
    
                public IEnumerator<Cell<T>> GetEnumerator()
                {
                    foreach (var cell in this.history)
                        yield return cell;
                }
    
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
    
                public BoardView<U> Transform<U>(Func<T, U> transform)
                {
                    var result = new BoardView<U>(new Size(Columns, Rows));
                    for (int y = 0; y < Rows; y++)
                    {
                        for (int x = 0; x < Columns; x++)
                        {
                            result[x, y] = transform(this[x, y]);
                        }
                    }
                    return result;
                }
    
                public void WriteAsGrid(TextWriter w)
                {
                    WriteAsGrid(w, "{0}");
                }
    
                public void WriteAsGrid(TextWriter w, string format)
                {
                    WriteAsGrid(w, x => string.Format(format, x.Data));
                }
    
                public void WriteAsGrid(TextWriter w, Func<Cell<T>, string> perCell)
                {
                    for (int y = 0; y < Rows; y++)
                    {
                        for (int x = 0; x < Columns; x++)
                        {
                            if (x != 0)
                                w.Write(",");
                            w.Write(perCell(this.SafeLookup(x, y)));
                        }
                        w.WriteLine();
                    }
                }
    
                #endregion
            }
    
            public class Rand
            {
                Random r;
    
                public Rand()
                {
                    var rand = System.Security.Cryptography.RandomNumberGenerator.Create();
                    byte[] b = new byte[4];
                    rand.GetBytes(b);
                    r = new Random(BitConverter.ToInt32(b, 0));
                }
    
                public int Next(int maxValue)
                {
                    return r.Next(maxValue);
                }
    
                public double NextDouble(double maxValue)
                {
                    return r.NextDouble() * maxValue;
                }
    
                public T Pick<T>(IEnumerable<T> things)
                {
                    return things.ElementAt(Next(things.Count()));
                }
    
                public T PickBias<T>(Func<T, double> bias, IEnumerable<T> things)
                {
                    double d = NextDouble(things.Sum(x => bias(x)));
                    foreach (var x in things)
                    {
                        if (d < bias(x))
                            return x;
                        d -= bias(x);
                    }
                    throw new InvalidOperationException("fell off the end!");
                }
            }
            #endregion
        }
    
        public static class Extensions
        {
            public static bool IsIn(this Point p, Size size)
            {
                return p.X >= 0 && p.Y >= 0 && p.X < size.Width && p.Y < size.Height;
            }
    
            public static bool IsLegal(this Ship ship,
                IEnumerable<Ship> ships,
                Size board,
                Point location,
                ShipOrientation direction)
            {
                var temp = new Ship(ship.Length);
                temp.Place(location, direction);
                if (!temp.GetAllLocations().All(p => p.IsIn(board)))
                    return false;
                return ships.Where(s => s.IsPlaced).All(s => !s.ConflictsWith(temp));
            }
    
            public static bool IsTouching(this Point a, Point b)
            {
                return (a.X == b.X - 1 || a.X == b.X + 1) &&
                    (a.Y == b.Y - 1 || a.Y == b.Y + 1);
            }
    
            public static bool IsTouching(this Ship ship,
                IEnumerable<Ship> ships,
                Point location,
                ShipOrientation direction)
            {
                var temp = new Ship(ship.Length);
                temp.Place(location, direction);
                var occupied = new HashSet<Point>(ships
                    .Where(s => s.IsPlaced)
                    .SelectMany(s => s.GetAllLocations()));
                if (temp.GetAllLocations().Any(p => occupied.Any(b => b.IsTouching(p))))
                    return true;
                return false;
            }
    
            public static ReadOnlyCollection<Ship> MakeShips(params int[] lengths)
            {
                return new System.Collections.ObjectModel.ReadOnlyCollection<Ship>(
                    lengths.Select(l => new Ship(l)).ToList());
            }
    
            public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Battleship.ShuggyCoUk.Simple.Rand rand)
            {
                T[] elements = source.ToArray();
                // Note i > 0 to avoid final pointless iteration
                for (int i = elements.Length - 1; i > 0; i--)
                {
                    // Swap element "i" with a random earlier element it (or itself)
                    int swapIndex = rand.Next(i + 1);
                    T tmp = elements[i];
                    elements[i] = elements[swapIndex];
                    elements[swapIndex] = tmp;
                }
                // Lazily yield (avoiding aliasing issues etc)
                foreach (T element in elements)
                {
                    yield return element;
                }
            }
    
            public static T RandomOrDefault<T>(this IEnumerable<T> things, Battleship.ShuggyCoUk.Simple.Rand rand)
            {
                int count = things.Count();
                if (count == 0)
                    return default(T);
                return things.ElementAt(rand.Next(count));
            }
        }
}
