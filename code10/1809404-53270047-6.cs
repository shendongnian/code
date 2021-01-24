    public struct Data
    {
        public Data(int value) => Value = value;
        public int Value { get; }
        public string Text => $"{nameof(Data)}: {Value}";
    }
