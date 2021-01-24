    class Addition
    (
        private readonly int result;
 
        public Addition(int num1, int num2)
        {
            result = num1 + num2;
        }
        public override string ToString()
        {
            return result.ToString();
        }
    }
