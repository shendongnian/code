    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace DSA
    {
        class Calculator
        {
            string PFE;
            public Calculator()
            {
                Console.WriteLine("Intializing Calculator");
            }
    
            public double Calculate(string expression)
            {
                ConvertToPost(expression);
                return CalculatePOST();
            }
    
            public void ConvertToPost(string expression)
            {
                expression = "(" + expression + ")";
              
                var temp = new DSA.Stack<char>();
                string ch = string.Empty;
                bool unary = true;
                char a;
                foreach (var b in expression)
                {
                    a = b;
                    if (!a.IsOperator()) {
                        ch += a.ToString();
                        unary = false;
                    }
                    else
                    {
                        if (ch!=string.Empty) 
                        PFE += ch+",";
                        ch = string.Empty;
                        if(a!='(' && a!=')')
                        {
                            if (unary == true)
                            {
                                if (a == '-') a = '~'; else if (a == '+') a = '#'; else throw new InvalidOperationException("invalid input string");
                            }
                            try
                            {
                                if (a.Precedence() <= temp.Peek().Precedence())
                                {
                                    PFE += temp.Pop().ToString() + ",";
                                }
                              }
                            catch(InvalidOperationException e)
                            {
                               
                            }
                            
                                temp.Push(a);
                                unary = true;
                        }
                        if (a == '(') { temp.Push(a);}
                        if(a==')')
                        {
                           for(char t=temp.Pop();t!='(';t=temp.Pop())
                            {
                                PFE += t.ToString() + ","; 
                            }
                        }
                    }
                      
                }
              
            }
    
            public double CalculatePOST()
            {
                var eval = new Stack<double>();
                string ch = string.Empty;
                bool skip = false;
                foreach(char c in PFE)
                {
                    if(!c.IsOperator())
                    {
                        if (c == ',')
                        {
                            if (skip == true)
    
                            {
                                skip = false;
                                continue;
                            }
                            eval.Push(Double.Parse(ch));
                            ch = string.Empty;
                        }
                        else ch += c;
                    }
                    else
                    {
                        if (c == '~')
                        {
                            var op1 = eval.Pop();
                            eval.Push(-op1);
                        }
                        else if (c == '#') ;
                        else
                        {
                            var op2 = eval.Pop();
                            var op1 = eval.Pop();
                            eval.Push(Calc(op1, op2, c));
                        }
                        skip = true;
                    }
                  }
                return eval.Pop();
            }
    
            private double Calc(double op1, double op2, char c)
            {   
               switch(c)
                {
                 
                    case '+':
                        return op1 + op2;
                    case '-':
                        return op1 - op2;
                    case '*':
                        return op1 * op2;
                    case '%':
                        return op1 % op2;
                    case '/':
                        return op1 / op2;
                    case '^':
                        return float.Parse(Math.Pow(op1,op2).ToString());
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    
    
        public static class extension
        {
            public static bool IsOperator(this char a)
            {
                char[] op = {'+','-','/','*','(',')','^','!','%','~','#'};
                 return op.Contains(a);
            }
    
            public static int Precedence(this char a)
            {
                if (a == '~' || a== '#')
                    return 1;
                if (a == '^')
                    return 0;
                if (a == '*' || a == '/' || a=='%')
                    return -1;
                if (a == '+' || a == '-')
                    return -2;
                return -3;       
            }       
        }
    }
