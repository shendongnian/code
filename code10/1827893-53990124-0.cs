    public class TextPosition
    {
        public int StartPos { get; set; }
        public int EndPos { get; set; }
        public static readonly TextPosition[] Positions = new[] {
            new TextPosition { StartPos = 11, EndPos = 17 },
            new TextPosition { StartPos = 18, EndPos = 25 }
        } 
    }
