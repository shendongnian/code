        public void Multiply()
        {
            if (array.Length < 2)
                return;
            var factor1 = Pop();
            var factor2 = Pop();
            Push(factor1 * factor2);
        }
        public void Divide()
        {
            if (array.Length < 2)
                return;
            var numerator = Pop();
            var divisor = Pop();
            if (divisor == 0)
                return;
            Push(numerator / divisor);
        }
