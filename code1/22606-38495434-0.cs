    class RPN
    {
        public static double Parse( Stack<string> strStk )
        {
            if (strStk == null || strStk.Count == 0 )
            {
                return 0;
            }
            Stack<double> numStk = new Stack<double>();
            double result = 0;
            Func<double, double> op = null;
            while (strStk.Count > 0)
            {
                var s = strStk.Pop();
                switch (s)
                {
                    case "+":
                        op = ( b ) => { return numStk.Pop() + b; };
                        break;
                    case "-":
                        op = ( b ) => { return numStk.Pop() - b; };
                        break;
                    case "*":
                        op = ( b ) => { return numStk.Pop() * b; };
                        break;
                    case "/":
                        op = ( b ) => { return numStk.Pop() / b; };
                        break;
                    default:
                        double.TryParse(s, NumberStyles.Any, out result);
                        if (numStk.Count > 0)
                        {
                            result = op(result);
                        }
                        numStk.Push(result);
                        break;
                }
            }
            return result;
        }
    }
    ....
    var str = " 100.5 + 300.5 - 100 * 10 / 100";    
    str = Regex.Replace(str, @"\s", "", RegexOptions.Multiline);
    Stack<string> strStk = new Stack<string>(
         Regex.Split(str, @"([()*+\/-])", RegexOptions.Multiline).Reverse()
    );
    RPN.Parse(strStk);
