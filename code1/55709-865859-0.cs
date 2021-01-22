    class Something : ISomething {
        public const int Zero = 0;
        public const int One = 1;
        public void DoesSomething(int x) {
            if (x == Zero) {
                x = One;
            }
        }
    }
