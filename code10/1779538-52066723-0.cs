    public class myRectangle
    {
        private Rectangle newRectangle = new Rectangle();
        private string name;
        
        public myRectangle Rectangle(Int32 Y, Int32 X, Int32 Height, Int32 Width, string name )
        {
           newRectangle.Y = Y;
           newRectangle.X = X;
           newRectangle.Height = Height;
           newRectangle.Width = Width;
           this.name = name;
           return this;
        }
    }
