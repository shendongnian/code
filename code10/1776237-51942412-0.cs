    class Program
    {
        static void Main(string[] args)
        {
            string[] operators = { "+", "-", "/", "*" };
            string test = "X+8X-21X+21X+16";
            int locationcounter = 0;
            string part = string.Empty;
            List<Part> partsList = new List<Part>();
    
            for (int i = 0; i < test.Length; i++)
            {
                if (operators.Contains(test[i].ToString()))
                {
                    var operatorbeofore = (partsList.Count <= 0 ? "" : partsList[partsList.Count - 1].OperatorAfter);
                    partsList.Add(new Part(part, operatorbeofore, test[i].ToString(), locationcounter));
                    locationcounter++;
                    part = string.Empty;
                }
                else
                {
                    part += test[i].ToString();
                }
            }
    
            // last part that remain
            if (part != string.Empty)
            {
                partsList.Add(new Part(part, partsList[partsList.Count() - 1].OperatorAfter, "", locationcounter++));
            }
            // output
            Console.WriteLine(GetResultOutput(partsList));
            Console.ReadLine();
        }
    
        private static string GetResultOutput(List<Part> algebraicexpression)
        {
            // reduce all vars
            var vars = algebraicexpression.Where(x => x.IsVar).OrderBy(x => x.locationInEqution).ToList();
            int lastVarResult = 0;
            int varResult = 0;
            if (vars.Count() > 1)
            {
                lastVarResult = GetCalculation(vars[0].Value, vars[1].Value, vars[1].OperatorBefore);
                for (int i = 2; i < vars.Count(); i++)
                {
                    varResult = GetCalculation(lastVarResult, vars[i].Value, vars[i].OperatorBefore);
                    lastVarResult = varResult;
                }
            }
            else if (vars.Count() == 1)
            {
                lastVarResult = vars[0].Value;
            }
            // calculate all "free" numbers
            var numbers = algebraicexpression.Where(x => x.IsVar == false).OrderBy(x => x.locationInEqution).ToList();
            int lastResult = 0;
            int Result = 0;
            if (numbers.Count() > 1)
            {
                lastResult = GetCalculation(vars[0].Value, vars[1].Value, vars[1].OperatorBefore);
                for (int i = 2; i < vars.Count(); i++)
                {
                    Result = GetCalculation(lastResult, vars[i].Value, vars[i].OperatorBefore);
                    lastResult = varResult;
                }
            }
            else if (numbers.Count() == 1)
            {
                Result = numbers[0].Value;
            }
    
            string stringresult = string.Empty;
            if (varResult != 0)
            {
                stringresult = varResult.ToString() + vars[0].Notation;
            }
    
            if (Result > 0)
            {
                stringresult = stringresult + "+" + Result.ToString();
            }
            else if (Result < 0)
            {
                stringresult = stringresult + "-" + Result.ToString();
            }
    
            return stringresult;
        }
    
        private static int GetCalculation(int x, int y, string eqoperator)
        {
            if (eqoperator == "+")
            {
                return x + y;
            }
            else if (eqoperator == "-")
            {
                return x - y;
            }
            else if (eqoperator == "*")
            {
                return x * y;
            }
            else if (eqoperator == "/")
            {
                return x / y;
            }
            else
            {
                return 0;
            }
    
        }
    }
    
    class Part
    {
        public string MyAlgebricPart;
        public string OperatorBefore;
        public string OperatorAfter;
        public int locationInEqution;
    
        public Part(string part, string operatorbefore, string operatorafter, int location)
        {
            this.MyAlgebricPart = part;
            this.OperatorAfter = operatorafter;
            this.OperatorBefore = operatorbefore;
            this.locationInEqution = location;
        }
    
        public int Value
        {
            get
            {
                if (MyAlgebricPart.Count() == 1 && Notation != string.Empty)
                {
                    return 1;
                }
                else
                {
                    string result = new String(MyAlgebricPart.Where(Char.IsDigit).ToArray());
                    return Convert.ToInt32(result);
                }
            }
        }
        public string Notation
        {
            get
            {
                var onlyLetters = new String(MyAlgebricPart.Where(Char.IsLetter).ToArray());
                if (onlyLetters != "")
                {
                    return onlyLetters[0].ToString();
                }
                else
                {
                    return string.Empty;
                }
    
            }
        }
    
        public bool IsVar
        {
            get
            {
                if (Notation == string.Empty)
                    return false;
                else
                    return true;
            }
        }
    }
