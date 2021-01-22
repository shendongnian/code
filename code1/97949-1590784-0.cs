        public string PrintMethodName()
        {
            return new StackFrame(1, false).GetMethod().Name;
        }
        private void Hi()
        {
            Console.WriteLine(PrintMethodName());
        }
