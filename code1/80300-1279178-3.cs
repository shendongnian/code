    public class YourObject
    {
    
        public Point Location { get; set; }
        public Size Size {get; set; }
    
        public bool IsHit(int x, int y)
        {
            Rectangle rc = new Rectangle(this.Location, this.Size);
            return rc.Contains(x, y);
        }
    }
