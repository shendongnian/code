    class TextMold : DataMold<string>
    {
        public string Result => "ABC";
        public override string ToString() => Result.ToString();
    }
