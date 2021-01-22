    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            public enum MyNumberType { Zero = 0, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten }
    
            private static int GetIntValue(MyNumberType theType) { return (int) theType; }
            private static String GetStringValue(MyNumberType theType) { return Enum.GetName(typeof (MyNumberType),theType); }
            private static MyNumberType GetEnumValue (int theInt) {
                return (MyNumberType) Enum.Parse( typeof(MyNumberType), theInt.ToString() ); }
    
            static void Main(string[] args)
            {
                Console.WriteLine( "{0} {1} {2}", 
                    GetIntValue(MyNumberType.Five), 
                    GetStringValue( MyNumberType.Three),
                    GetEnumValue(7)
                    );
                for (int i=0; i<=10; i++)
                {
                    Console.WriteLine("{0}", GetEnumValue(i));
                }
            }
        }
    }
