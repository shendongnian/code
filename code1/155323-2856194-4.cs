    public partial class Window1 : Window
    {
           public Window1()
        {
            this.Resources["ColorList"] = new[] { Color.Red, Color.Blue, Color.Green };
            InitializeComponent();
        }
           private Color _activeColor;
        public Color ActiveColor
        {
            get { return _activeColor; }
            set
            {
                _activeColor = value;
            }
        }
    }
    public class ColorList : List<Color> { }
    public enum Color
    {
        Red,
        Blue,
        Green
    }
