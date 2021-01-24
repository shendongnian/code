    public class PictureBoxEventArgs : EventArgs
    {
        public PictureBoxEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
    }
