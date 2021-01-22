        private static IEnumerable<T> pairSwitch<T>(IEnumerable<T> input)
        {
            T current = input.FirstOrDefault();     // just to satisfy compiler
            bool odd = true;
            foreach (T element in input)
            {
                if (odd) current = element;
                else
                {
                    yield return element;
                    yield return current;
                }
                odd = !odd;
            }
        }
        static void Main(string[] args)
        {
            string test = "Hello";
            string result = new string(pairSwitch(test).ToArray());
