    public class Union<A, B, C>
    {
        private readonly Type type;
        public readonly A a;
        public readonly B b;
        public readonly C c;
        public Union(A a)
        {
            type = typeof(A);
            this.a = a;
        }
        public Union(B b)
        {
            type = typeof(B);
            this.b = b;
        }
        public Union(C c)
        {
            type = typeof(C);
            this.c = c;
        }
        public bool Value(TypeTestSelector<A> _)
        {
            return typeof(A) == type;
        }
        public bool Value(TypeTestSelector<B> _)
        {
            return typeof(B) == type;
        }
        public bool Value(TypeTestSelector<C> _)
        {
            return typeof(C) == type;
        }
        public A Value(GetValueTypeSelector<A> _)
        {
            return a;
        }
        public B Value(GetValueTypeSelector<B> _)
        {
            return b;
        }
        public C Value(GetValueTypeSelector<C> _)
        {
            return c;
        }
    }
    public static class Is
    {
        public static TypeTestSelector<T> OfType<T>()
        {
            return null;
        }
    }
    public class TypeTestSelector<T>
    {
    }
    public static class Get
    {
        public static GetValueTypeSelector<T> ForType<T>()
        {
            return null;
        }
    }
    public class GetValueTypeSelector<T>
    {
    }
