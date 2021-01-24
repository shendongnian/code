    public class Example
    {
        public static void Main(string[] args)
        {
            var target = new Mistery();
            foreach (var field in target.GetType().GetFields(BindingFlags.Instance | 
                                                             BindingFlags.NonPublic))
            {
                Console.WriteLine("{0}={1}", field.Name, field.GetValue(target));
            }
        }
    }
    public class Mistery
    {
        private string _secret = "hello123";
    }
