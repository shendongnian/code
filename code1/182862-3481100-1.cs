    public class ItemSet
    {
        public ItemSet()
        {
            this.X = -1;
            this.Y = -1;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public void SetItems(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
