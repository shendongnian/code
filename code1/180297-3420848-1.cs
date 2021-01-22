    public class MyObject 
    {
        public Color Rgb { get; private set; }
        public MyObject(int foo, string bar, Color? rgb = null) 
        { 
            this.Rgb = rgb ?? Color.Transparent;
            // .... 
        } 
    }
