    public static class Clone
    {        
        // ReSharper disable once InconsistentNaming
        public static void CloneObjectWithIL<T>(T source, T los)
        {
            //see http://lindexi.oschina.io/lindexi/post/C-%E4%BD%BF%E7%94%A8Emit%E6%B7%B1%E5%85%8B%E9%9A%86/
            if (CachedIl.ContainsKey(typeof(T)))
            {
                ((Action<T, T>) CachedIl[typeof(T)])(source, los);
                return;
            }
            var dynamicMethod = new DynamicMethod("Clone", null, new[] { typeof(T), typeof(T) });
            ILGenerator generator = dynamicMethod.GetILGenerator();
            foreach (var temp in typeof(T).GetProperties().Where(temp => temp.CanRead && temp.CanWrite))
            {
                //do not copy static that will except
                if (temp.GetAccessors(true)[0].IsStatic)
                {
                    continue;
                }
                
                generator.Emit(OpCodes.Ldarg_1);// los
                generator.Emit(OpCodes.Ldarg_0);// s
                generator.Emit(OpCodes.Callvirt, temp.GetMethod);
                generator.Emit(OpCodes.Callvirt, temp.SetMethod);
            }
            generator.Emit(OpCodes.Ret);
            var clone = (Action<T, T>) dynamicMethod.CreateDelegate(typeof(Action<T, T>));
            CachedIl[typeof(T)] = clone;
            clone(source, los);
        }
        private static Dictionary<Type, Delegate> CachedIl { set; get; } = new Dictionary<Type, Delegate>();
    }
