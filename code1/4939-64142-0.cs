        abstract class MathProvider<T>
        {
            public abstract T Divide(T a, T b);
            public abstract T Multiply(T a, T b);
            public abstract T Add(T a, T b);
            public abstract T Negate(T a);
            public virtual T Subtract(T a, T b)
            {
                return Add(a, Negate(b));
            }
        }
        class DoubleMathProvider : MathProvider<double>
        {
            public override double Divide(double a, double b)
            {
                return a / b;
            }
            public override double Multiply(double a, double b)
            {
                return a * b;
            }
            public override double Add(double a, double b)
            {
                return a + b;
            }
            public override double Negate(double a)
            {
                return -a;
            }
        }
        class IntMathProvider : MathProvider<int>
        {
            public override int Divide(int a, int b)
            {
                return a / b;
            }
            public override int Multiply(int a, int b)
            {
                return a * b;
            }
            public override int Add(int a, int b)
            {
                return a + b;
            }
            public override int Negate(int a)
            {
                return -a;
            }
        }
        class Fraction<T>
        {
            static MathProvider<T> _math;
            // Notice this is a type constructor.  It gets run the first time a
            // variable of a specific type is declared for use.
            // Having _math static reduces overhead.
            static Fraction()
            {
                // This part of the code might be cleaner by once
                // using reflection and finding all the implementors of
                // MathProvider and assigning the instance by the one that
                // matches T.
                if (typeof(T) == typeof(double))
                    _math = new DoubleMathProvider() as MathProvider<T>;
                else if (typeof(T) == typeof(int))
                    _math = new IntMathProvider() as MathProvider<T>;
                // ... assign other options here.
                if (_math == null)
                    throw new InvalidOperationException(
                        "Type " + typeof(T).ToString() + " is not supported by Fraction.");
            }
            // Immutable impementations are better.
            public T Numerator { get; private set; }
            public T Denominator { get; private set; }
            public Fraction(T numerator, T denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            public static Fraction<T> operator +(Fraction<T> a, Fraction<T> b)
            {
                return new Fraction<T>(
                    _math.Add(a.Numerator, b.Numerator),
                    _math.Add(a.Denominator, b.Denominator));
            }
            public static Fraction<T> operator -(Fraction<T> a, Fraction<T> b)
            {
                return new Fraction<T>(
                    _math.Subtract(a.Numerator, b.Numerator),
                    _math.Subtract(a.Denominator, b.Denominator));
            }
            public static Fraction<T> operator /(Fraction<T> a, Fraction<T> b)
            {
                return new Fraction<T>(
                    _math.Multiply(a.Numerator, b.Denominator),
                    _math.Multiply(a.Denominator, b.Numerator));
            }
            // ... other operators would follow.
        }
