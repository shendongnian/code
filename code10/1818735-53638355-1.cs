    public class myButton : UIElement
    {
        public Button btn = new Button();
        public myButton(int width, int height, string content)
        {
            btn.Width = width;
            btn.Height = height;
            btn.Content = content;
        }
    }
