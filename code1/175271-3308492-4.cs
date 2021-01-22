    public class TestClass
    {
        private static MethodInfo innerMethodDefinition =
            typeof(TestClass).GetMethod("InnerMethod");
        public void Method(object data)
        {
            var t = data.GetType();
            while (t != null &&
                !(t.IsGenericType &&
                t.GetGenericTypeDefinition() == typeof(BaseType<>)))
            {
                t = t.BaseType;
            }
            if (t != null &&
                t.GetGenericArguments()[0].IsAssignableFrom(data.GetType()))
            {
                innerMethodDefinition.MakeGenericMethod(
                    t.GetGenericArguments()[0]).Invoke(this, new object[] { data });
            }
        }
        public void InnerMethod<TEntity>(TEntity data)
            where TEntity : BaseType<TEntity>
        {
            // Here you have the object with the correct type
        }
    }
