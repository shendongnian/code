        class TypeA
        {
            public int value;
        }
        class TypeB
        {
            public int number;
            public static explicit operator TypeB(TypeA v)
            {
                return new TypeB() { number = v.value };
            }
        }
        class TypeC : TypeB { }
        interface IFoo { }
        class TypeD : TypeA, IFoo { }
        void Run()
        {
            TypeA customTypeA = new TypeD() { value = 10 };
            long longValue = long.MaxValue;
            int intValue = int.MaxValue;
            // Casting 
            TypeB typeB = (TypeB)customTypeA; // custom explicit casting -- IL:  call class ConsoleApp1.Program/TypeB ConsoleApp1.Program/TypeB::op_Explicit(class ConsoleApp1.Program/TypeA)
            IFoo foo = (IFoo)customTypeA; // is-a reference -- IL: castclass  ConsoleApp1.Program/IFoo
            int loseValue = (int)longValue; // explicit -- IL: conv.i4
            long dontLose = intValue; // implict -- IL: conv.i8
            // AS 
            int? wraps = intValue as int?; // nullable wrapper -- IL:  call instance void valuetype [System.Runtime]System.Nullable`1<int32>::.ctor(!0)
            object o1 = intValue as object; // box -- IL: box [System.Runtime]System.Int32
            TypeD d1 = customTypeA as TypeD; // reference conversion -- IL: isinst ConsoleApp1.Program/TypeD
            IFoo f1 = customTypeA as IFoo; // reference conversion -- IL: isinst ConsoleApp1.Program/IFoo
            
            //TypeC d = customTypeA as TypeC; // wouldn't compile
        }
 
