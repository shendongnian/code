        public static void CombiParentheses(int open, int close, StringBuilder str)
        {
            if (open == 0 && close == 0)
            {
                Console.WriteLine(str.ToString());
            }
            if (open > 0) //when you open a new parentheses, then you have to close one parentheses to balance it out.
            {                
                CombiParentheses(open - 1, close + 1, str.Append("{"));
            }
            if (close > 0)
            {                
                CombiParentheses(open , close - 1, str.Append("}"));
            }
        }
