    public class Program
    {
        public static void Main()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"C:\Temp\test.config");
            //...
        }
    }
