        public Func<int> RandomGenerator
        {
            get
            {
                var r = new Random();
                return () => { return r.Next(); };
            }
        }
        void SomeFunction()
        {
            var result1 = RandomGenerator();
            var x = RandomGenerator;
            var result2 = x();
        }
