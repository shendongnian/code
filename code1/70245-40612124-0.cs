        public enum MyEnum
        {
            My_Word,
            Another_One_With_More_Words,
            One_More,
            We_Are_Done_At_Last
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                IEnumerable<MyEnum> values = Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>();
                List<string> valuesWithSpaces = new List<string>(values.Select(v => v.ToString().Replace("_", " ")));
    
                foreach (MyEnum enumElement in values)
                    Console.WriteLine($"Name: {enumElement}, Value: {(int)enumElement}");
    
                Console.WriteLine();
                foreach (string stringRepresentation in valuesWithSpaces)
                    Console.WriteLine(stringRepresentation);
            }
        }
