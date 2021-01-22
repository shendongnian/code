    namespace ExtendMe
    {
        public interface IDecorate { }
    
        public static class Extensions
        {
            public static void CommonMethod(this IDecorate o) { /* do stuff */ }
        }
    
        public class Blah :IDecorate {}
    
        public class Widget : IDecorate {}
    
        class Program
        {
            static void Main(string[] args)
            {
                new Blah().CommonMethod();
                new Widget().CommonMethod();
            }
        }
    }
