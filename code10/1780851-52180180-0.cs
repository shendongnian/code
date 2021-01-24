    class Program
    {
        static void Main(string[] args)
        {
            var spanGetter = typeof(Program).GetMethod("GetItem").MakeGenericMethod(typeof(float));
            var myFloatSpan = Expression.Parameter(typeof(Span<float>), "s");
            var myValue = Expression.Call(
                null,
                spanGetter,
                myFloatSpan,
                Expression.Constant(42));
            var myAdd = Expression.Add(
                myValue,
                Expression.Constant(13f));
            var expr = Expression.Lambda<MyFunc>(myAdd, myFloatSpan).Compile();
            var span = new Span<float>(new float[43]);
            span[42] = 12.3456f;
            Console.WriteLine(expr(span)); // -> 25.3456
        }
        // hopefully, this shouldn't be too bad in terms of performance...
        // C# knows how to do compile this, while Linq Expressions doesn't
        public static T GetItem<T>(Span<T> span, int index) => span[index];
        // we need that because we can't use a Span<T> directly with Func<T>
        // we could make it generic also I guess
        public delegate float MyFunc(Span<float> span);
    }
