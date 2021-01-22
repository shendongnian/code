        public static readonly Size  Grid     = new Size( 16, 16 );
        public static readonly Size  HalfGrid = new Size( Grid.Width/2, Grid.Height/2 );
        // ~~~~ Round to nearest Grid point ~~~~
        public Point  SnapCalculate( Point p )
        {
            int     snapX = ( ( p.X + HalfGrid.Width  ) / Grid.Width  ) * Grid.Width;
            int     snapY = ( ( p.Y + HalfGrid.Height ) / Grid.Height ) * Grid.Height;
            return  new Point( snapX, snapY );
        }
