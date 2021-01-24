    public partial abstract class Tool : UserControl
    {
        public TextBox TextBox { get; }
        public Tool(int marginRight, Shape shape,string text, string name)
        {
            ...
            TextBox = new TextBox
            {
               ...
            };
            grid.Children.Add(TextBox);
        }
    }
