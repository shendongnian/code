    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= (int)MenuSelection.MaxMenuSelection; i++)
            {
                Console.WriteLine($"[{i}] {((MenuSelection)i).GetEnumDescription()}");
            }
            Console.ReadLine();
        }
    }
    public static class Extensions
    {
        public static string GetEnumDescription(this MenuSelection m)
        {
            FieldInfo fi = m.GetType().GetField(m.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes != null && attributes.Length > 0 ? attributes[0].Description : m.ToString();
        }
    }
    public enum MenuSelection
    {
        [Description("Create Customer")]
        CreateCustomer = 1,
        [Description("Create Account")]
        CreateAccount = 2,
        [Description("Set Account Balance")]
        SetAccountBalance = 3,
        [Description("Display Account Balance")]
        DisplayAccountBalance = 4,
        Exit = 5,
        MaxMenuSelection = 5,
    }
