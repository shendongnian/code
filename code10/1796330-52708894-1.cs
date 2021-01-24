    public partial abstract class Tool : UserControl
    {
        public TextBox TextBox { get; }
        public Tool(...)
        {
            ...
            TextBox = new TextBox
            {
               ...
            };
            grid.Children.Add(TextBox);
        }
    }
