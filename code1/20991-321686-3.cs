    class Program
    {
        class MyObject
        {
            public int MyField;
        }
        
        static Action<T,TValue> MakeSetter<T,TValue>(FieldInfo field)
        {
            DynamicMethod m = new DynamicMethod(
                "setter", typeof(void), new Type[] { typeof(T), typeof(TValue) }, typeof(Program));
            ILGenerator cg = m.GetILGenerator();
            
            // arg0.<field> = arg1
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.Emit(OpCodes.Stfld, field);
            cg.Emit(OpCodes.Ret);
            
            return (Action<T,TValue>) m.CreateDelegate(typeof(Action<T,TValue>));
        }
        
        static void Main()
        {
            FieldInfo f = typeof(MyObject).GetField("MyField");
            
            Action<MyObject,int> setter = MakeSetter<MyObject,int>(f);
            
            var obj = new MyObject();
            obj.MyField = 10;
            
            setter(obj, 42);
            
            Console.WriteLine(obj.MyField);
            Console.ReadLine();
        }
    }
