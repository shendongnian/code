        // 2+(100/5)+10 = 32
        //((2.5+10)/5)+2.5 = 5
        // (2.5+10)/5+2.5 = 1.6666
        public static double Evaluate(String expr)
        {
            Stack<String> stack = new Stack<String>();
            string value = "";
            for (int i = 0; i < expr.Length; i++)
            {
                String s = expr.Substring(i, 1);
                char chr = s.ToCharArray()[0];
                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack.Push(value);
                    value = "";
                }
                if (s.Equals("(")) {
                    string innerExp = "";
                    i++; //Fetch Next Character
                    int bracketCount=0;
                    for (; i < expr.Length; i++)
                    {
                        s = expr.Substring(i, 1);
                        if (s.Equals("("))
                            bracketCount++;
                        if (s.Equals(")"))
                            if (bracketCount == 0)
                                break;
                            else
                                bracketCount--;
                            
                        innerExp += s;
                    }
                    stack.Push(Evaluate(innerExp).ToString());
                }
                else if (s.Equals("+")) stack.Push(s);
                else if (s.Equals("-")) stack.Push(s);
                else if (s.Equals("*")) stack.Push(s);
                else if (s.Equals("/")) stack.Push(s);
                else if (s.Equals("sqrt")) stack.Push(s);
                else if (s.Equals(")"))
                {
                }
                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += s;
                    if (value.Split('.').Length > 2)
                        throw new Exception("Invalid decimal.");
                    if (i == (expr.Length - 1))
                        stack.Push(value);
                }
                else
                    throw new Exception("Invalid character.");
                    
            }
            double result = 0;
            while (stack.Count >= 3)
            {
                double right = Convert.ToDouble(stack.Pop());
                string op = stack.Pop();
                double left = Convert.ToDouble(stack.Pop());
                if (op == "+") result = left + right;
                else if (op == "+") result = left + right;
                else if (op == "-") result = left - right;
                else if (op == "*") result = left * right;
                else if (op == "/") result = left / right;
                stack.Push(result.ToString());
            }
            return Convert.ToDouble(stack.Pop());
        }
