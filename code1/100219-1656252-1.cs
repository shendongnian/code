    class Cell<T> 
    {
        private readonly BoardView<T> view;
        public readonly int X;
        public readonly int Y;
        public T Data;
        public Cell(BoardView<T> view, int x, int y) 
        { 
            this.view = view;  this.X = x; this.Y = y; 
        }
        public Point Location
        {
            get { return new Point(X, Y); }
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
    }
    class BoardView<T>  : IEnumerable<Cell<T>>
    {
        private readonly int Columns;
        private readonly int Rows;
        private Cell<T>[,] history;
        public BoardView(Size size)
        {
            Columns = size.Width;
            Rows = size.Height;
            this.history = new Cell<T>[Columns, Rows];
            for (int x = 0; x < Columns;x++)
                for (int y = 0; y < Rows;y++)
                    history[x,y] = new Cell<T>(this,x,y);
        }
        public T this[int x, int y]
        {
            get { return history[x, y].Data; }
            set { history[x, y].Data = value; }
        }
        public T this[Point p]
        {
            get { return history[p.X, p.Y].Data; }
            set { this.history[p.X, p.Y].Data = value; }
        }
        public Cell<T> SafeLookup(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Columns || y >= Rows)
                return null;
            return history[x, y];
        }
        
        #region IEnumerable<Cell<T>> Members
        public IEnumerator<Cell<T>> GetEnumerator()
        {
            foreach (var cell in this.history)
                yield return cell;
        }
        System.Collections.IEnumerator 
            System.Collections.IEnumerable.GetEnumerator()
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
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    if (x != 0)
                        w.Write(",");
                    w.Write(format, this[x, y]);
                }
                w.WriteLine();
            }
        }
        #endregion
    }
