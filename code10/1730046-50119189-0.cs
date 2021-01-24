    public struct Point
        {
            /// <summary>
            /// The x position
            /// </summary>
            public int X { get; set; }
        
            /// <summary>
            /// The y position
            /// </summary>
            public int Y { get; set; }
        
            /// <summary>
            /// Sets the values of the struct
            /// </summary>
            /// <param name="x">initial x</param>
            /// <param name="y">initial y</param>
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
    }
