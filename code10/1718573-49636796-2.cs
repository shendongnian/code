    public class RowVM
    {
        public ButtonData Col1 { get; set; }
        public ButtonData Col2 { get; set; }
    }
    public class ButtonData
    {
        public string Content { get; set; }
        public ICommand Command { get; set; }
    }
