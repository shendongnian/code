    abstract class QuadTree<T>
    {
        public QuadTree(int width, int height)
        {
            this.Width = width;
            this.Heigth = heigth;
        }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public abstract T Get(int x, int y); 
    }
    class MatrixQuadTree<T> : QuadTree<T>
    {
        private readonly T[,] matrix;
        public QuadTree(T[,] matrix, int width, int heigth)
            : base(width, heigth)
        {
            this.matrix = matrix;
        }
    
        public override T Get(int x, int y)
        {
           return this.matrix[x, y];
        }
    }
    class CompositeQuadTree<T> : QuadTree<T>
    {
        private readonly QuadTree<T> topLeft;
        private readonly QuadTree<T> topRight;
        private readonly QuadTree<T> bottomLeft;
        private readonly QuadTree<T> bottomRight;
    
        public CompositeQuadTree(QuadTree<T> topLeft,
            QuadTree<T> topRight, QuadTree<T> bottomLeft,
            QuadTree<T> bottomRight)
            : base(topLeft.Width + topRight.Width, 
                topLeft.Height + bottomLeft.Heigth)
        {
            // TODO: Do proper checks.
            if (this.Width != topLeft.Width + bottomRight.Width)
                throw Exception();
    
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }
    
        public override T Get(int x, int y)
        {
            if (x <= this.topLeft.Width)
            {
                if (y <= this.topLeft.Width)
                {
                    return this.topLeft.Get(x, y);
                }
                else
                {
                    return this.topLeft.Get(x, y + this.topLeft.Heigth);
                }
            }
            else
            {
                if (y <= this.topLeft.Width)
                {
                    return this.topRight.Get(x + this.topLeft.Width, y);
                }
                else
                {
                    return this.topRight.Get(x + this.topLeft.Width, 
                        y + this.topLeft.Heigth);
                }
            }
        }
    }
