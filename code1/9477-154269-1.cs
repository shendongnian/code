    public class GetNamesTest {
        enum Colors { Red, Green, Blue, Yellow };
        enum Styles { Plaid, Striped, Tartan, Corduroy };
        public static void Main() {
            Console.WriteLine("The values of the Colors Enum are:");
            foreach(string s in Enum.GetNames(typeof(Colors)))
                Console.WriteLine(s);
            Console.WriteLine();
            Console.WriteLine("The values of the Styles Enum are:");
            foreach(string s in Enum.GetNames(typeof(Styles)))
                Console.WriteLine(s);
        }
    }
