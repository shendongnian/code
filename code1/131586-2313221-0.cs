       class Program
        {
            static void Main(string[] args)
            {
                TestMethod();
                Console.ReadLine();
            }
    
            static string TestMethod()
            {
                using (new Me())
                {
                    return "Yes";
                }
            }
        }
    
        class Me : IDisposable
        {
            #region IDisposable Members
    
            public void Dispose()
            {
                Console.WriteLine("Disposed");
            }
    
            #endregion
        }
