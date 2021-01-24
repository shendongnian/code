    namespace MyExcelFunctions
    {
        [ComVisible(true)]
        public interface IFunctions { string OddOrEven(int number); }
    
        [ComVisible(true)]
        [ComDefaultInterface(typeof(IFunctions))]
        public class Functions : IFunctions
        {
            public string OddOrEven(int number)
            {
                return number % 2 == 0 ? "Even" : "Odd";
            }
    
            private static string GetSubKeyName(Type type)
            {
                string s = @"CLSID\{" + type.GUID.ToString().ToUpper() + @"}\Programmable";
                return s;
            }
    
            [ComRegisterFunction]
            public static void RegisterFunction(Type type)
            {
                Registry.ClassesRoot.CreateSubKey(GetSubKeyName(type));
            }
    
            [ComUnregisterFunction]
            public static void UnregisterFunction(Type type)
            {
                Registry.ClassesRoot.DeleteSubKey(GetSubKeyName(type));
            }
        }
    
    }
