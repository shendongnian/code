    public static class Cloner
    {
        static Dictionary<Type, Delegate> _cachedIL = new Dictionary<Type, Delegate>();
        public static T Clone<T>(T myObject)
        {
            Delegate myExec = null;
            if (!_cachedIL.TryGetValue(typeof(T), out myExec))
            {
                var dymMethod = new DynamicMethod("DoClone", typeof(T), new Type[] { typeof(T) }, true);
                var cInfo = myObject.GetType().GetConstructor(new Type[] { });
                var generator = dymMethod.GetILGenerator();
                var lbf = generator.DeclareLocal(typeof(T));
                generator.Emit(OpCodes.Newobj, cInfo);
                generator.Emit(OpCodes.Stloc_0);
                foreach (var field in myObject.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    // Load the new object on the eval stack... (currently 1 item on eval stack)
                    generator.Emit(OpCodes.Ldloc_0);
                    // Load initial object (parameter)          (currently 2 items on eval stack)
                    generator.Emit(OpCodes.Ldarg_0);
                    // Replace value by field value             (still currently 2 items on eval stack)
                    generator.Emit(OpCodes.Ldfld, field);
                    // Store the value of the top on the eval stack into the object underneath that value on the value stack.
                    //  (0 items on eval stack)
                    generator.Emit(OpCodes.Stfld, field);
                }
                // Load new constructed obj on eval stack -> 1 item on stack
                generator.Emit(OpCodes.Ldloc_0);
                // Return constructed object.   --> 0 items on stack
                generator.Emit(OpCodes.Ret);
                myExec = dymMethod.CreateDelegate(typeof(Func<T, T>));
                _cachedIL.Add(typeof(T), myExec);
            }
            return ((Func<T, T>)myExec)(myObject);
        }
    }
