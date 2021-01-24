    public enum Test
    {
        [EnumMember(Value = "True")]
        @true,
        @false
    }
    class Program
    {
        static void Main()
        {
            Test a = JsonConvert.DeserializeObject<Test>("\"true\"");
            Console.WriteLine(a); //true
        }
    }
