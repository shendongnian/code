    class Program
    {
        static void ThrowMyException()
        {
            throw new MyException(hideThrowingMethodFromStackFrame: true);
        }
        static void Foo()
        {
            ThrowMyException();
        }
        static void Main()
        {
            try
            {
                Foo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
