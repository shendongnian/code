    class Data
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Data[,] map = new Data[3, 3];
            map[1, 1] = new Data();
            map[1, 1].Text = "Test";
        }
    }
