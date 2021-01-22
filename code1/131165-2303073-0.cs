    delegate Point PositionFunction(int time);
    class MovingBitmap
    {
        private Bitmap bitmap;
        private PositionFunction positionFunction;
        public MovingBitmap(Bitmap bitmap, PositionFunction positionFunction)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("bitmap");
            }
            else if (positionFunction == null)
            {
                throw new ArgumentNullException("bitmap");
            }
            this.bitmap = bitmap;
            this.positionFunction = positionFunction;
        }
        public Bitmap Bitmap
        {
            get { return this.bitmap; }
        }
        public PositionFunction PositionFunction
        {
            get { return this.positionFunction; }
        }
    }
