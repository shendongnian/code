        public abstract class SafeAnon<TContext>
        {
            public static Anon<T> Create<T>(Func<T> anonFactory)
            {
                return new Anon<T>(anonFactory());
            }
            public abstract void Fire(TContext context);
            public class Anon<T> : SafeAnon<TContext>
            {
                private readonly T _out;
                public delegate void Delayed(TContext context, T anon);
                public Anon(T @out)
                {
                    _out = @out;
                }
                public event Delayed UseMe;
                public override void Fire(TContext context)
                {
                    UseMe?.Invoke(context, _out);
                }
            }
        }
        public static SafeAnon<SomeContext> Test()
        {
            var sa = SafeAnon<SomeContext>.Create(() => new { AnonStuff = "asdf123" });
            sa.UseMe += (ctx, anon) =>
            {
                ctx.Stuff.Add(anon.AnonStuff);
            };
            return sa;
        }
        public class SomeContext
        {
            public List<string> Stuff = new List<string>();
        }
