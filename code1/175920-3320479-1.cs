    // Usage
    Monkey monkey = new Monkey() { numberOfEyes = 7, name = "Henry" };
    Dog dog = new Dog();
    DynamicCopy.CopyProperties<IAnimal>(monkey, dog);
    Debug.Assert(dog.numberOfEyes == monkey.numberOfEyes);
    ...    
    // The copier
    public static class DynamicCopy
    {
        public static void CopyProperties<T>(T source, T target)
        {
            Helper<T>.CopyProperties(source, target);
        }
        private static class Helper<T>
        {
            private static readonly Action<T, T>[] _copyProps = Prepare();
            private static Action<T, T>[] Prepare()
            {
                Type type = typeof(T);
                ParameterExpression source = Expression.Parameter(type, "source");
                ParameterExpression target = Expression.Parameter(type, "target");
                var copyProps = from prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                where prop.CanRead && prop.CanWrite
                                let getExpr = Expression.Property(source, prop)
                                let setExpr = Expression.Call(target, prop.GetSetMethod(true), getExpr)
                                select Expression.Lambda<Action<T, T>>(setExpr, source, target).Compile();
                return copyProps.ToArray();
            }
            public static void CopyProperties(T source, T target)
            {
                foreach (Action<T, T> copyProp in _copyProps)
                    copyProp(source, target);
            }
        }
    }
