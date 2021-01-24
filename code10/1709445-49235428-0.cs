    public class ChangePixelCommand : Command
    {    
        private Color _previousColor;
        private int x;
        private int y;
    
        public virtual void Execute(Bitmap image, int x, int y, Color color)
        {
            // record the data needed to undo this operation.
            _previousColor = image.GetPixel(x, y);
            _x = x;
            _y = y;
    
            // update the image.
            image.SetPixel(x, y, color);
        }
     
        public virtual Void Undo(Bitmap image)
        {
            //  Use the data we saved earlier to put the pixel back the way it was.
            image.SetPixel(_x, _y, _previousColor);
        }
    }
