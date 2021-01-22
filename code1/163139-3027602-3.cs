    class Rational : INumber<Rational>
    {
        public int Sign { get { /* ... */ } }
        public Rational Scale(double amount) { /* ... */ }
    }
    class RationalFactory : INumberFactory<Rational>
    {
        Rational Parse(string text);
    }
