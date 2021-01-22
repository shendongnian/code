        private static String ReverseString(String str)
        {
            int word_length = 0;
            String result = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    result = " " + result;
                    word_length = 0;
                }
                else
                {
                    result = result.Insert(word_length, str[i].ToString());
                    word_length++;
                }
            }
            return result;
        }
    //NASSIM LOUCHANI
        public static string SplitLineToMultiline(string input, int rowLength)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();
            Stack<string> stack = new Stack<string>(ReverseString(input).Split(' '));
            
            while (stack.Count > 0)
            {
                var word = stack.Pop();
                if (word.Length > rowLength)
                {
                    string head = word.Substring(0, rowLength);
                    string tail = word.Substring(rowLength);
                    word = head;
                    stack.Push(tail);
                }
                if (line.Length + word.Length > rowLength)
                {
                    result.AppendLine(line.ToString());
                    line.Clear();
                }
                line.Append(word + " ");
            }
            result.Append(line);
            return result.ToString();
        }
