        private void foo()
        {
            try
            {
                bar(3);
                bar(2);
                bar(1);
                bar(0);
            }
            catch(DivideByZeroException)
            {
                //log message and rethrow...
                throw;
            }
        }
        private void bar(int b)
        {
            int a = 1;
            int c = a/b;  // Generate divide by zero exception.
        }
