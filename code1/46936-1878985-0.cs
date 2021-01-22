    public static class ObjectExtensions {
        public static string GetVariableName<T>(this T obj) {
            System.Reflection.PropertyInfo[] objGetTypeGetProperties = obj.GetType().GetProperties();
            if(objGetTypeGetProperties.Length == 1)
                return objGetTypeGetProperties[0].Name;
            else
                throw new ArgumentException("object must contain one property");
        }
    }
	
    class Program {
        static void Main(string[] args) {
            string strName = "sdsd";
            Console.WriteLine(new {strName}.GetVariableName());
            int intName = 2343;
            Console.WriteLine(new { intName }.GetVariableName());
        }
    }
