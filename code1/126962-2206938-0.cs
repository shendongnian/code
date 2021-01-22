    public class Base
    {
        
        private delegate Base ConstructorDelegate(int someParam);
    
        public class ClassReference
        {
            Type currentType = typeof(Base);
    
            public Base Create<U>() where U : Base
            {
                ConstructorInfo ci = currentType.GetConstructor(BindingFlags.Instance |
                BindingFlags.Public, null, Type.EmptyTypes, null);
                DynamicMethod dm = new DynamicMethod("CreateInstance", typeof(Base), Type.EmptyTypes, typeof(ClassReference));
                ILGenerator il = dm.GetILGenerator();
                il.Emit(OpCodes.Newobj, ci);
                il.Emit(OpCodes.Ret);
                ConstructorDelegate del = (ConstructorDelegate)dm.CreateDelegate(typeof(ConstructorDelegate));
                return del();
            }
    
            public Base Create<U>(int someParam) where U : Base
            {
                ConstructorInfo ci = currentType.GetConstructor(BindingFlags.Instance |
                BindingFlags.Public, null, new Type[] { typeof(int) }, null);
                DynamicMethod dm = new DynamicMethod("CreateInstance", typeof(Base), new Type[] {
                typeof(int) }, typeof(ClassReference));
                ILGenerator il = dm.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Newobj, ci);
                il.Emit(OpCodes.Ret);
                ConstructorDelegate del = (ConstructorDelegate)dm.CreateDelegate(typeof(ConstructorDelegate));
                return del(someParam);
            }
    
            private ClassReference(Type type)
            {
                currentType = type;
            }
            internal ClassReference() { }
    
            public static implicit operator ClassReference(Type input)
            {
                if (!typeof(Base).IsAssignableFrom(input))
                    throw new Exception(String.Format("Type {0} must derive from {1}", input,
                    typeof(Base)));
                return new ClassReference(input);
            }
        }
    
    
    }
