    class Test
    {
        static void Main()
        {
            if (DateTime.Now.Hour > 12)
            {
    #region Foo
                Console.WriteLine("Afternoon");            
            }
    #endregion
        }
    }
