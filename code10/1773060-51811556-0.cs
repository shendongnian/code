    public class Ball
    {
        private Color _color;
        public Ball(Color color)
        {
            _color = color;
        }
        public int GetColorRedValue()
        {
            return _color.GetRed();
        }
    }
