    class TextMold : DataMold<string>
    {
        public string Result
        {
            get { return "ABC"; }
        }
        public override string ToString()
        {
            return Result.ToString();
        }
    }
