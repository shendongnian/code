    class Foo
    {
        public readonly int X
        public readonly int Y
        public Foo(int x, int y, Bar bar)
        {
            this.X = x; 
            bar.ShowYourself(this);
            this.Y = y;
            bar.ShowYourself(this);
        }
    }
