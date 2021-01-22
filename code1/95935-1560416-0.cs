    private static List<screenLocation> screenLocationsBasic = new List<screenLocation>();
    public class screenLocation
    {
        public int Left { get; set; }
        public int Top { get; set; }
    
        public screenLocation(int left, int top)
        {
            this.Left = left;
            this.Top = top; 
        }
    
        
    }
