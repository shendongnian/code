    static void Main(string[] args)
        {
            try
            {
                M1();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" -----------------Stack Trace Hierarchy -----------------");
                Console.WriteLine(ex.StackTrace.ToString());
                Console.WriteLine(" ---------------- Method Name / Target Site -------------- ");
                Console.WriteLine(ex.TargetSite.ToString());
            }
            Console.ReadKey();
        }
        static void M1()
        {
            try
            {
                M2();
            }
            catch (Exception ex)
            {
                throw;
            };
        }
        static void M2()
        {
            throw new DivideByZeroException();
        }
