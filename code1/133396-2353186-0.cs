    using System;
    using System.Reflection.Emit;
    public delegate object ParamsConstructorDelegate(params object[] parameters);
    public class Foo
    {
        string s;
        int i;
        float? f;
        public Foo(string s, int i, float? f)
        {
            this.s = s;
            this.i = i;
            this.f = f;
        }
    }
    
    static class Program
    {
        static void Main()
        {
            var ctor = Build(typeof(Foo));
            Foo foo1 = (Foo)ctor("abc", 123, null);
            Foo foo2 = (Foo)ctor(null, 123, 123.45F);
        }
        static ParamsConstructorDelegate Build(Type type)
        {
            var mthd = new DynamicMethod(".ctor", type,
                new Type[] { typeof(object[]) });
            var il = mthd.GetILGenerator();
            var ctor = type.GetConstructors()[0]; // not very robust, but meh...
            var ctorParams = ctor.GetParameters();
            for (int i = 0; i < ctorParams.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_0);
                switch (i)
                {
                    case 0: il.Emit(OpCodes.Ldc_I4_0); break;
                    case 1: il.Emit(OpCodes.Ldc_I4_1); break;
                    case 2: il.Emit(OpCodes.Ldc_I4_2); break;
                    case 3: il.Emit(OpCodes.Ldc_I4_3); break;
                    case 4: il.Emit(OpCodes.Ldc_I4_4); break;
                    case 5: il.Emit(OpCodes.Ldc_I4_5); break;
                    case 6: il.Emit(OpCodes.Ldc_I4_6); break;
                    case 7: il.Emit(OpCodes.Ldc_I4_7); break;
                    case 8: il.Emit(OpCodes.Ldc_I4_8); break;
                    default: il.Emit(OpCodes.Ldc_I4, i); break;
                }
                il.Emit(OpCodes.Ldelem_Ref);
                Type paramType = ctorParams[i].ParameterType;
                il.Emit(paramType.IsValueType ? OpCodes.Unbox_Any
                    : OpCodes.Castclass, paramType);
            }
            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Ret);
            return (ParamsConstructorDelegate)
                mthd.CreateDelegate(typeof(ParamsConstructorDelegate));
        }
    }
