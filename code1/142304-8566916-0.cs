    using System.Reflection;
    using System.Reflection.Emit;
    public class ObjectCreateMethod
    {
        delegate object MethodInvoker();
        MethodInvoker methodHandler = null;
        public ObjectCreateMethod(Type type)
        {
            CreateMethod(type.GetConstructor(Type.EmptyTypes));
        }
        public ObjectCreateMethod(ConstructorInfo target)
        {
            CreateMethod(target);
        }
        void CreateMethod(ConstructorInfo target)
        {
            DynamicMethod dynamic = new DynamicMethod(string.Empty,typeof(object),new Type[0], target.DeclaringType);
            ILGenerator il = dynamic.GetILGenerator();
            il.DeclareLocal(target.DeclaringType);
            il.Emit(OpCodes.Newobj, target);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);
            methodHandler = (MethodInvoker)dynamic.CreateDelegate(typeof(MethodInvoker));
        }
        public object CreateInstance()
        {
            return methodHandler();
        }
    }
