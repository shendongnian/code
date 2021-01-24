    public class PictureBox
    {
        private Color _backColor;
        public void SetBackColor(Color color)
        {
            //getting class type that called this method
            var stackTrace = new StackTrace();
            var stackFrames = stackTrace.GetFrames();
            var callingFrame = stackFrames[1];
            var method = callingFrame.GetMethod();
            //checking if the class type is GameManager
            if (!method.DeclaringType.IsAssignableFrom(typeof(GameManager)))
            {
                throw new FieldAccessException("Only GameManager can set the background color of a PictureBox!");
            }
            _backColor = color;
        }
        public Color BackColor => _backColor;
    }
    public class Tile
    {
        public PictureBox tilePB { get; set; }
    }
    //example GameManager class
    public class GameManager
    {
        public void SetBackground()
        {
            var someTile = new Tile()
            {
                tilePB = new PictureBox()
            };
            var someColor = new Color();
            someTile.tilePB.SetBackColor(someColor);
        }
    }
    //example class that may want to set picturebox background color
    public class MaliciousClass
    {
        public void SetBackground()
        {
            var someTile = new Tile()
            {
                tilePB = new PictureBox()
            };
            var someColor = new Color();
            someTile.tilePB.SetBackColor(someColor);
        }
    }
