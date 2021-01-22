    public class Test {
        public static void Main() {
            System.DateTime? dt = null;
            System.Console.WriteLine("<{0}>", dt.ToString());
            dt = System.DateTime.Now;
            System.Console.WriteLine("<{0}>", dt.ToString());
        }
    }
