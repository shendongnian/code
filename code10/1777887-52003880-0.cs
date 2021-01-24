    class Program
    {
        static void Main(string[] args)
        {
            var enumAsString = "Value1";
            Enum.TryParse(enumAsString, out SomeEnum enumeration);
            if (enumeration == SomeEnum.Value1)
                Console.WriteLine("success");
        }
    }
    public enum SomeEnum
    {
        Value1,
        Value2
    }
