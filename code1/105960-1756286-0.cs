    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            Throws<ArgumentNullException>(() => File.OpenText(null));
        }
        
        public static void Throws<ExceptionType>(Action cmd)
            where ExceptionType : Exception
        {
            try
            {
                try
                {
                    cmd();
                }
                catch (ExceptionType)
                {
                    Console.WriteLine("Caught!");
                    return;
                }
            }
            catch (Exception f)
            {
                Console.WriteLine("Threw an exception of type " + f.GetType() 
                    + ".  Expected type was " + typeof(ExceptionType) + ".");
            }
    
            Console.WriteLine("No exception thrown");
        }
    }
