    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace GenericPratice1
    {
        public delegate T Del<T>(T numone, T numtwo)where T:struct;
        class Class1
        {
            public T Addition<T>(T numone, T numtwo) where T:struct
            {
                return ((dynamic)numone + (dynamic)numtwo);
            }
            public T Substraction<T>(T numone, T numtwo) where T : struct
            {
                return ((dynamic)numone - (dynamic)numtwo);
            }
            public T Division<T>(T numone, T numtwo) where T : struct
            {
                return ((dynamic)numone / (dynamic)numtwo);
            }
            public T Multiplication<T>(T numone, T numtwo) where T : struct
            {
                return ((dynamic)numone * (dynamic)numtwo);
            }
    
            public Del<T> GetMethodInt<T>(int ch)  where T:struct
            {
                Console.WriteLine("Enter the NumberOne::");
                T numone =(T) Convert.ChangeType((object)(Console.ReadLine()), typeof(T));
                Console.WriteLine("Enter the NumberTwo::");
                T numtwo = (T)Convert.ChangeType((object)(Console.ReadLine()), typeof(T));
                T result = default(T);
                Class1 c = this;
                Del<T> deleg = null;
                switch (ch)
                {
                    case 1:
                        deleg = c.Addition<T>;
                        result = deleg.Invoke(numone, numtwo);
                        break;
                    case 2: deleg = c.Substraction<T>;
                        result = deleg.Invoke(numone, numtwo);
                        break;
                    case 3: deleg = c.Division<T>;
                        result = deleg.Invoke(numone, numtwo);
                        break;
                    case 4: deleg = c.Multiplication<T>;
                        result = deleg.Invoke(numone, numtwo);
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
                Console.WriteLine("Result is:: " + result);
                return deleg;
            }
            
        }
        class Calculator
        {
            public static void Main(string[] args)
            {
                Class1 cs = new Class1();
                Console.WriteLine("Enter the DataType choice:");
                Console.WriteLine("1 : Int\n2 : Float");
                int sel = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the choice::");
                Console.WriteLine("1 : Addition\n2 : Substraction\3 : Division\4 : Multiplication");
                int ch = Convert.ToInt32(Console.ReadLine());
                if (sel == 1)
                {
                    cs.GetMethodInt<int>(ch);
                }
                else
                {
                    cs.GetMethodInt<float>(ch);
                }
               
            }
        }
    }
