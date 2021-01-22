     struct ScreenPosition
    {
        // These are the two private members of the structure 
        private int x;
        private int y;
        private int RangeCheckedX(int xPos)
        {
            if (xPos < 0 || xPos > 1280)
            {
                throw new ArgumentOutOfRangeException("X");
            }
            return xPos;
        }
        private int RangeCheckedY(int yPos)
        {
            if (yPos < 0 || yPos > 1024)
            {
                throw new ArgumentOutOfRangeException("Y");
            }
            return yPos;
        }
        // Declaring the non-default constructor
        public ScreenPosition(int X, int Y)
        {
            this.x = X; 
            this.y = Y; 
            this.x = RangeCheckedX(X);
            this.y = RangeCheckedY(Y);
        }
        // Declaring  the property X - Follows a syntax. See the C# quick reference sheet 
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = RangeCheckedX(value);
            }
        }
        // Declaring  the property X - Follows a syntax. See the C# quick reference sheet 
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = RangeCheckedY(value);
            }
        }
    }
