        // Slightly sneaky, we pass both the wrapped class and the wrapping class as type parameters to the generic class
        // allowing it to create instances of either as necessary.
        public abstract class CoolClass<T, U>
            where U : CoolClass<T, U>, new()
        {
            public T Value { get; private set; }
            public abstract T DoSomethingCool();
            // Non-public constructor
            protected CoolClass()
            {
            }
            public CoolClass(T value)
            {
                Value = value;
            }
            public static implicit operator CoolClass<T, U>(T val)
            {
                return new U() { Value = val};
            }
            public static implicit operator T(CoolClass<T, U> obj)
            {
                return obj.Value;
            }
        }
        public class CoolInt : CoolClass<int, CoolInt>
        {
            public CoolInt()
            { 
            }
            public CoolInt(int val)
                : base(val)
            {
            }
            public override int DoSomethingCool()
            {
                return this.Value * this.Value; // Ok, so that wasn't THAT cool
            }
        }
