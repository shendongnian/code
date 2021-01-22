        private void InvokeHelper(Action method)
        {
            bool retry = false;
            do
            {
                try
                {
                    method();
                    retry = false;
                }
                catch (MyException ex)
                {
                    retry = HandleException(ex);
                }
            } while (retry);
        }
        public void Test()
        {
            FooClass foo = new FooClass();
            InvokeHelper( () => foo.MethodA(1, "b", 3) );
            InvokeHelper( () => foo.MethodB(2, "y"));
        }
