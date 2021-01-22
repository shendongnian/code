    public class RestrictedNumber<T> : IEquatable<RestrictedNumber<T>>, IComparable<RestrictedNumber<T>>
        where T: IEquatable<T>,IComparable<T>
    {
        T min;
        T max;
        readonly T value;
        public RestrictedNumber(T min, T max, T value)
        {
            this.min = min;
            this.max = max;
            this.value = value;
        }
        public T UnrestrictedValue
        {
            get{ return value; }
        }
        public static implicit operator T(RestrictedNumber<T> n)
        {
            return get_restricted_value(n);
        }
        public static implicit operator RestrictedNumber<T>(T value)
        {
            return new RestrictedNumber<T>(value, value, value);
        }
        static T get_restricted_value(RestrictedNumber<T> n)
        {
            // another yoink from Jon Skeet
            return n.value.CompareTo(n.min) < 0 ? n.min
                : n.value.CompareTo(n.max) > 0 ? n.max
                    : n.value;
        }
        T restricted_value
        {
            get { return get_restricted_value(value); }
        }
        public T Min // optional to expose this
        {
            get { return this.min; }
            set { this.min = value; } // optional to provide a setter
        }
        public T Max // optional to expose this
        {
            get { return this.max; }
            set { this.max = value; } // optional to provide a setter
        }
        public bool Equals(RestrictedNumber<T> other)
        {
            return restricted_value.Equals(other);
        }
        public int CompareTo(RestrictedNumber<T> other)
        {
            return restricted_value.CompareTo(other);
        }
        public override string ToString()
        {
            return restricted_value.ToString();
        }
    }
    public class RestrictedNumberExercise
    {
        public void ad_hoc_paces()
        {
            // declare with min, max, and value
            var i = new RestrictedNumber<int>(1, 10, 15);
            Debug.Assert(i == 10d);
            Debug.Assert(i.UnrestrictedValue == 15d);
            // declare implicitly
            // my implementation initially sets min and max equal to value
            RestrictedNumber<double> d = 15d;
            d.Min = 1;
            d.Max = 10;
            
            Debug.Assert(i == 10d); // compare with other, "true" doubles
            Debug.Assert(i.UnrestrictedValue == 15d); // still holds the original value
            RestrictedNumber<decimal> m = new RestrictedNumber<decimal>(55.5m,55.5m,55.499m);
            Debug.Assert(m == 55.5m);
            Debug.Assert(m > m.UnrestrictedValue); // test out some other operators
            Debug.Assert(m >= m.UnrestrictedValue); // we didn't have to define these
            Debug.Assert(m + 10 == 65.5m); // you even get unary operators
            RestrictedNumber<decimal> other = 50m;
            Debug.Assert(m > other); // compare two of these objects
            Debug.Assert(other <= m); // ...again without having to define the operators
            Debug.Assert(m - 5.5m == other); // unary works with other Ts
            Debug.Assert(m + other == 105.5m); // ...and with other RestrictedNumbers
            Debug.Assert(55.5m - m == 0);
            Debug.Assert(m - m == 0);
            // passing to method that expects the primitive type
            Func<float,float> square_float = f => f * f;
            RestrictedNumber<float> restricted_float = 3;
            Debug.Assert(square_float(restricted_float) == 9f);
            // this sort of implementation is not without pitfalls
            // there are other IEquatable<T> & IComaparable<T> types out there...
            var restricted_string = new RestrictedNumber<string>("Abigail", "Xander", "Yolanda");
            Debug.Assert(restricted_string == "Xander"); // this works
            //Debug.Assert(restricted_string >= "Thomas"); // many operators not supported here
            var pitfall = new RestrictedNumber<int>(1, 100, 200);
            Debug.Assert(pitfall == 100);
            pitfall = 200;
            // Debug.Assert(pitfall == 100);
            // FAIL -- using the implicit operator is effectively
            // a factory method that returns a NEW RestrictedNumber
            // with min and max initially equal to value (in my implementation)
            Debug.Assert(pitfall == 200);
            pitfall = 10;
            Debug.Assert(pitfall.Min == 10 && pitfall.Max == 10);
            pitfall++;
            Debug.Assert(pitfall == 11); // d'oh!
            Debug.Assert(pitfall.Min == 11 && pitfall.Max == 11); // "it goes up to eleven"
            // if you need to change the input value for an existing
            // RestrictedNumber, you could expose a SetValue method
            // and make value not readonly
        }
    }
