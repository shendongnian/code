    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading;
    using System.Windows.Forms;
    class Program {
        static ParameterInfo[] VerifyStandardHandler(Type type) {
            if (type == null) throw new ArgumentNullException("type");
            if (!typeof(Delegate).IsAssignableFrom(type)) throw new InvalidOperationException();
            MethodInfo sig = type.GetMethod("Invoke");
            if (sig.ReturnType != typeof(void)) throw new InvalidOperationException();
            ParameterInfo[] args = sig.GetParameters();
            if (args.Length != 2 || args[0].ParameterType != typeof(object)) throw new InvalidOperationException();
            if (!typeof(EventArgs).IsAssignableFrom(args[1].ParameterType)) throw new InvalidOperationException();
            return args;
        }
        static int methodIndex;
        static Delegate Wrap(Delegate value, Type type) {
            ParameterInfo[] destArgs = VerifyStandardHandler(type);
            if (value == null) return null; // trivial
            if (value.GetType() == type) return value; // already OK
            ParameterInfo[] sourceArgs = VerifyStandardHandler(value.GetType());
            string name = "_wrap" + Interlocked.Increment(ref methodIndex);
            Type[] paramTypes = new Type[destArgs.Length + 1];
            paramTypes[0] = value.GetType();
            for (int i = 0; i < destArgs.Length; i++) {
                paramTypes[i + 1] = destArgs[i].ParameterType;
            }
            DynamicMethod dyn = new DynamicMethod(name, null, paramTypes);
            MethodInfo invoker = paramTypes[0].GetMethod("Invoke");
            ILGenerator il = dyn.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldarg_2);
            if (!sourceArgs[1].ParameterType.IsAssignableFrom(destArgs[1].ParameterType)) {
                il.Emit(OpCodes.Castclass, sourceArgs[1].ParameterType);
            }
            il.Emit(OpCodes.Call, invoker);
            il.Emit(OpCodes.Ret);
            return dyn.CreateDelegate(type, value);
        }
        static void Main() {
            EventHandler handler = delegate(object sender, EventArgs eventArgs) {
                Console.WriteLine(eventArgs.GetType().Name);
            };
            MouseEventHandler wrapper = (MouseEventHandler)Wrap(handler, typeof(MouseEventHandler));
            MouseEventArgs ma = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
            wrapper(new object(), ma);
            EventHandler backAgain = (EventHandler)Wrap(wrapper, typeof(EventHandler));
            backAgain(new object(), ma);
        }
    }
