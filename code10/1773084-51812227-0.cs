    public class ButtonValues
    {
        public int i { get; set; }
        public int j { get; set; }
    }
    Button b = new Button();
    b.Tag = new ButtonValues { i = i, j = j };
