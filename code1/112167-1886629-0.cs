    public class MyException : Exception
    {
        public string CustomField { get; set; }
        public override string ToString()
        {
            return CustomField + Environment.NewLine + base.ToString();
        }
    }
