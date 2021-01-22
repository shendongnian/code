        public static string Reverse(string text)
        {
            var stack = new Stack<char>(text);
            var array = new char[stack.Count];
            int i = 0;
            while (stack.Count != 0)
            {
                array[i++] = stack.Pop();
            }
            return new string(array);
        }
