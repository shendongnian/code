    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace HelloWorld
    {
        class Program
        {
            static int ReturnInt(Foo test)
            {
                int retVal = 0; // defaults to 0
    
                int someOtherValue = 4; // <---Value may change depending on X
    
    
                switch (test)
                {
                    case Foo.Bar:
                        
                            if (someOtherValue > 20)
                                retVal = 1;
                            break;
                        
                    case Foo.Zoo:
                        
                            if (someOtherValue == 5)
                                retVal = 4;
                            break;
                        
                    case Foo.Boo:
                        
                            if (someOtherValue == 2)
                                retVal = 7;
                            break;
                        
                    default:
                            retVal = 0;
                            break;
                        
                }
                return retVal;
            }
    
            enum Foo
            {
                Bar,
                Zoo,
                Boo
            }
    
            static void Main(string[] args)
            {
                Foo test = Foo.Bar;
    
                Console.WriteLine(ReturnInt(test));
            }
        }
    }
