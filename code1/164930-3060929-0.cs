    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace ConsoleApplication2
    {
        using System;
        class Program
        {
            static void Main()
            {
                WriteDeltas(new Foo {X = 123, Y = DateTime.Today, Z = null},
                            new Foo {X = 124, Y = DateTime.Today, Z = null});
                WriteDeltas(new Foo { X = 123, Y = DateTime.Today, Z = null },
                            new Foo { X = 123, Y = DateTime.Now, Z = new Dummy()});
                WriteDeltas(new Bar { X = 123, Y = DateTime.Today, Z = null },
                            new Bar { X = 124, Y = DateTime.Today, Z = null });
                WriteDeltas(new Bar { X = 123, Y = DateTime.Today, Z = null },
                            new Bar { X = 123, Y = DateTime.Now, Z = new Dummy() });
            }
            static void WriteDeltas<T>(T x, T y)
            {
                Console.WriteLine("----");
                foreach(string delta in PropertyComparer<T>.GetDeltas(x,y))
                {
                    Console.WriteLine(delta);
                }
    
            }
    
        }
        class Dummy {}
        class Foo
        {
            public int X { get; set; }
            public DateTime Y { get; set; }
            public Dummy Z { get; set; }
        }
        struct Bar
        {
            public int X { get; set; }
            public DateTime Y { get; set; }
            public Dummy Z { get; set; }
        }
    
        public static class PropertyComparer<T>
        {
            private static readonly Func<T, T, List<string>> getDeltas;
            static PropertyComparer()
            {
                var dyn = new DynamicMethod(":getDeltas", typeof (List<string>), new[] {typeof (T), typeof (T)},typeof(T));
                var il = dyn.GetILGenerator();
                il.Emit(OpCodes.Newobj, typeof (List<string>).GetConstructor(Type.EmptyTypes));
                bool isValueType = typeof (T).IsValueType;
                OpCode callType = isValueType ? OpCodes.Call : OpCodes.Callvirt;
                var add = typeof(List<string>).GetMethod("Add");
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (!prop.CanRead) continue;
                    Label next = il.DefineLabel();
                    switch (Type.GetTypeCode(prop.PropertyType))
                    {
                        case TypeCode.Boolean:
                        case TypeCode.Byte:
                        case TypeCode.Char:
                        case TypeCode.Double:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.SByte:
                        case TypeCode.Single:
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                            if(isValueType) {il.Emit(OpCodes.Ldarga_S, (byte)0);} else {il.Emit(OpCodes.Ldarg_0);}
                            il.EmitCall(callType, prop.GetGetMethod(), null);
                            if (isValueType) { il.Emit(OpCodes.Ldarga_S, (byte)1); } else { il.Emit(OpCodes.Ldarg_1); }
                            il.EmitCall(callType, prop.GetGetMethod(), null);
                            il.Emit(OpCodes.Ceq);
                            break;
                        default:
                            var pp = new Type[] {prop.PropertyType, prop.PropertyType};
                            var eq = prop.PropertyType.GetMethod("op_Equality", BindingFlags.Public | BindingFlags.Static, null, pp, null);
                            if (eq != null)
                            {
                                if (isValueType) { il.Emit(OpCodes.Ldarga_S, (byte)0); } else { il.Emit(OpCodes.Ldarg_0); }
                                il.EmitCall(callType, prop.GetGetMethod(), null);
                                if (isValueType) { il.Emit(OpCodes.Ldarga_S, (byte)1); } else { il.Emit(OpCodes.Ldarg_1); }
                                il.EmitCall(callType, prop.GetGetMethod(), null);
                                il.EmitCall(OpCodes.Call, eq, null);
    
                            }
                            else
                            {
                                il.EmitCall(OpCodes.Call, typeof(EqualityComparer<>).MakeGenericType(prop.PropertyType).GetProperty("Default").GetGetMethod(), null);
                                if (isValueType) { il.Emit(OpCodes.Ldarga_S, (byte)0); } else { il.Emit(OpCodes.Ldarg_0); }
                                il.EmitCall(callType, prop.GetGetMethod(), null);
                                if (isValueType) { il.Emit(OpCodes.Ldarga_S, (byte)1); } else { il.Emit(OpCodes.Ldarg_1); }
                                il.EmitCall(callType, prop.GetGetMethod(), null);
                                il.EmitCall(OpCodes.Callvirt, typeof(EqualityComparer<>).MakeGenericType(prop.PropertyType).GetMethod("Equals", pp), null);
                            }
                            break;
                    }
                    il.Emit(OpCodes.Brtrue_S, next); // equal
                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Ldstr, prop.Name);
                    il.EmitCall(OpCodes.Callvirt, add, null);
                    il.MarkLabel(next);
                }
                il.Emit(OpCodes.Ret);
                getDeltas = (Func<T, T, List<string>>)dyn.CreateDelegate(typeof (Func<T, T, List<string>>));
            }
            public static List<string> GetDeltas(T x, T y) { return getDeltas(x, y); }
    
        }
    }
