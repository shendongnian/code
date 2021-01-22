    class Rational {
        private:
            long numerator;
            long denominator;
        public:
            void Rational (long n, long d) {
                numerator = n;
                denominator = d;
            }
            void Rational (long n): Rational (n,1) {}
            void Rational (void): Rational (0,1) {}
            void Rational (String s): Rational (atoi(s),1) {}
    }
