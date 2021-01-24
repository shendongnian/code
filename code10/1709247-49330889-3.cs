    class Trace
    {
        public Trace()
        {
            this.Board = null;
            this.Counter = -1;
        }
        public Trace(Board board, int counter)
        {
            this.Board = board;
            this.Counter = counter;
        }
        public bool IsShorterThen(int counter)
        {
            return this.Counter > 0 && this.Counter <= counter;
        }
        public Board Board { get; set; }
        public int Counter { get; set; }
    }
    class Board
    {
        private int[][] _board;
        public Board(int N, int M)
        {
            this._board = new int[N][];
            for (int i = 0; i < N; i++)
            {
                this._board[i] = new int[M];
                for (int j = 0; j < M; j++)
                {
                    this._board[i][j] = 0;
                }
            }
        }
        public int N
        {
            get
            {
                return this._board.Length;
            }
        }
        public int M
        {
            get
            {
                return this._board.Length > 0 ? this._board[0].Length : 0;
            }
        }
        public Board GetEmptyCopy()
        {
            return new Board(this.N, this.M);
        }
        public Board GetCopy()
        {
            Board b = new Board(this.N, this.M);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    b.Set(i, j, this.Get(i, j));
                }
            }
            return b;
        }
        public bool Contains(int i, int j)
        {
            return (i >= 0) && (i < this.N) && (j >= 0) && (j < this.M);
        }
        public bool Contains(Point point)
        {
            return this.Contains(point.X, point.Y);
        }
        public bool IsFree(int i, int j)
        {
            return this._board[i][j] == 0;
        }
        public bool IsFree(Point point)
        {
            return this.IsFree(point.X, point.Y);
        }
        public void Set(int i, int j, int val)
        {
            this._board[i][j] = val;
        }
        public int Get(int i, int j)
        {
            return this._board[i][j];
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    str += String.Format("{0, 3}", this._board[i][j]);
                }
                str += "\r\n";
            }
            return str;
        }
    }
    class Knight
    {        
        public Knight(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point[] AllPossibleMoves()
        {
            Point[] moves = new Point[8];
            moves[0] = new Point(this.X + 1, this.Y + 2);
            moves[1] = new Point(this.X + 1, this.Y - 2);
            moves[2] = new Point(this.X + 2, this.Y + 1);
            moves[3] = new Point(this.X + 2, this.Y - 1);
            moves[4] = new Point(this.X - 1, this.Y + 2);
            moves[5] = new Point(this.X - 1, this.Y - 2);
            moves[6] = new Point(this.X - 2, this.Y + 1);
            moves[7] = new Point(this.X - 2, this.Y - 1);
            return moves;
        }
        public bool IsInPoint(int x, int y)
        {
            return this.X == x && this.Y == y;
        }
        public bool IsInPoint(Point point)
        {
            return this.IsInPoint(point.X, point.Y);
        }
        public void MoveTo(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void MoveTo(Point point)
        {
            this.MoveTo(point.X, point.Y);
        }
    }
    class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
    }
