    using System;
    
    class Test
    {
        static void Main()
        {
            Uri uri = new Uri("http://www.test.com/SomeOther/Test/Test.php?args=1");
            Console.WriteLine(uri.Host); // Prints www.test.com
        }
    }
