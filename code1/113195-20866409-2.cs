    public static class Ref
    {
        public static Ref<T>[] Create<T>(params Expression<Func<T>>[] getters)
        {
            return getters.Select(Create).ToArray();
        }
    
        public static Ref<T> Create<T>(Expression<Func<T>> getter)
        {
            return new Ref<T>(getter);
        }
    }
    
    public sealed class Ref<T>
    {
        readonly Func<T> getter;
        readonly Action<T> setter;
    
        public Ref(Expression<Func<T>> getter)
        {
            var output = getter.Body;
            var input = Expression.Parameter(output.Type); //or hardcode typeof(T)
            var assign = Expression.Assign(output, input);
            var setter = Expression.Lambda<Action<T>>(assign, input);
    
            this.getter = getter.Compile();
            this.setter = setter.Compile();
        }
    
        public T Value
        {
            get { return getter(); }
            set { setter(value); }
        }
    }
    public static void Fill(this SomeClass c, params Ref<object>[] p)
    //assign inside
    object i = 0, i2 = 0, i3 = 0;
    c.Fill(Ref.Create(() => i, () => i2, () => i3));
    //i, i2 etc changed
