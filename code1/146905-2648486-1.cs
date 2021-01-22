    internal class Example
    {
        private static void Main()
        {
            string[] names = new string[] { "Andrew", "Nicole", "Michael", "Joe", "Sammy", "Joshua" };
            IEnumerable<string> shortNames = names.Where<string>(delegate (string n) {
                return n.Length == 6;
            });
            string first = names.First<string>();
        }
    }
