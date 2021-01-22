    class MyOption
    {
        public static readonly MyOption Alpha = new MyOption(1, 10, "Alpha Text");
        public static readonly MyOption Bravo = new MyOption(2, 100, "Bravo Text");
        public static readonly MyOption Charlie = new MyOption(3, 1000, "Charlie Text");
        // ... Other options ...
        public static readonly MyOption Default = new MyOption(0, 0, null);
        public MyOption(int id, int value, string text)
        {
            this.ID = id;
            this.Value = value;
            this.Text = text;
        }
        public int ID { get; private set; }
        public int Value { get; private set; }
        public string Text { get; private set; }
    }
