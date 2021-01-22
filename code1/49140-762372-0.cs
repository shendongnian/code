    public class MyModel
    {
        public int Width{ get; set; }
        public int Height{ get; set; }
    
        public Size Size{ get{ return new Size( Width, Height ); }}
    };
