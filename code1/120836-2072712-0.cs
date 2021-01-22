    namespace Linq1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyType o = new MyType();
                o.Property.GetDisplayName();
            }
        }
        public class MyType
        {
            public IDisplayableProperty Property { get; set; }
        }
        public interface IDisplayableProperty 
        {
            string GetText();
        }
        public class MyProperty1 : IDisplayableProperty 
        {
            public string GetText() { return "MyProperty2"; }
        }
        public class MyProperty2 : IDisplayableProperty 
        {
            public string GetText() { return "MyProperty2"; }
        }
        public static class Extensions
        {
            public static string GetDisplayName(this IDisplayableProperty o)
            {
                return o.GetText();
            }
        }
    }
