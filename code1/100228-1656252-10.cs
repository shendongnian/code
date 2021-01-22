    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.IO;
    
    namespace Battleship.ShuggyCoUk
    {
        public enum Compass
        {
            North,East,South,West
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
                get { return view.SafeLookup(X+1, Y); }
            }
    
            public Cell<T> West
            {
                get { return view.SafeLookup(X-1, Y); }
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
    
        class BoardView<T>  : IEnumerable<Cell<T>>
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
                {    if (throwIfIllegal)
                        throw new ArgumentOutOfRangeException("["+x+","+y+"]");
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
                        result[x,y] = transform(this[x, y]);
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
    
            public void WriteAsGrid(TextWriter w, Func<Cell<T>,string> perCell)
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
    }
