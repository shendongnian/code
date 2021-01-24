    using System;
    namespace ConsoleApplication1 {
        class Program {
            static void Main( string[] args ) {
                Calculator calculator = new Calculator();
                Console.Write( "   Enter first operand:       " );
                calculator.FirstOperand = Convert.ToDouble( Console.ReadLine() ); //get the first
                Console.Write( "   Enter first operand:       " );
                calculator.SecondOperand = Convert.ToDouble( Console.ReadLine() ); //get the second
                calculator.Addition(); //Do addition
                Console.WriteLine( "Addition Result: {0}", calculator.Result ); //show result
                Console.WriteLine( "Press any key to continue....." );
                Console.ReadLine();
            }
        
        }
        class Calculator {
            private double firstOperand, secondOperand, result; //double data members
            //3 public properties
            public double FirstOperand {
                get { return firstOperand; }
                set { firstOperand = value; }
            }
            public double SecondOperand {
                get { return secondOperand; }
                set { secondOperand = value; }
            }
            public double Result {
                get { return result; }
                set { result = value; }
            }
            //1 public method Addition()
            public double Addition() {
                return result = firstOperand + secondOperand;
            }
        }
    }
