    public static class Cloner<T>
    {
        private static Func<T, T> cloner = CreateCloner();
        private static Func<T, T> CreateCloner()
        {
            var cloneMethod = new DynamicMethod("CloneImplementation", typeof(T), new Type[] { typeof(T) }, true);
            var defaultCtor = typeof(T).GetConstructor(new Type[] { });
            var generator = cloneMethod .GetILGenerator();
            var loc1 = generator.DeclareLocal(typeof(T));
            generator.Emit(OpCodes.Newobj, defaultCtor);
            generator.Emit(OpCodes.Stloc, loc1);
            foreach (var field in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                generator.Emit(OpCodes.Ldloc, loc1);
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, field);
                generator.Emit(OpCodes.Stfld, field);
            }
            generator.Emit(OpCodes.Ldloc, loc1);
            generator.Emit(OpCodes.Ret);
            return ((Func<T, T>)cloneMethod.CreateDelegate(typeof(Func<T, T>)));
        }
        public static T Clone(T myObject)
        {
            return cloner(myObject);
        }
    }
