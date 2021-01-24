    public class EvalMath
    {
        public double result { get; private set; }
        private delegate double Operation(double x, double y);
        public EvalMath()
        {
        }
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public double Eval(string operation)
        {
            operation = Reverse(operation);
            Operation op = null;
            if (operation == null) throw new EvalArgumentException();
            string integer1_r = "";
            foreach (char chr in operation)
            {
                if(chr == '+' || chr == '-' || chr == '*' || chr == '/')
                {
                    string integer = operation.Substring(0, operation.IndexOf(chr));
                    string integer1 = operation.Substring(operation.IndexOf(chr) + 1);
                    if(integer1.Contains("+") || integer1.Contains("-") || integer1.Contains("*") || integer1.Contains("/"))  integer1_r = Eval(integer.ToString()).ToString();
                    else integer1_r = integer1;
					
					switch (chr)
                    {
                        case '+':
                            op = (x, y) => x + y;
                            break;
                        case '-':
                            op = (x, y) => x - y;
                            break;
                        case '*':
                            op = (x, y) => x * y;
                            break;
                        case '/':
                            op = (x, y) => x / y;
                            break;
                    }
                    System.Windows.Forms.MessageBox.Show(integer + " " + integer1_r); // for debug
                    result = op(Convert.ToDouble(integer), Convert.ToDouble(integer1_r));
                    return result;
                }
            }
            return 0.0;
        }
    }
