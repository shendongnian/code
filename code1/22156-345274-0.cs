    using System;
    class A
    {
        public static void Main()
        {
            for (int i =0; i< 10; i++)
            {
                decimal? testDecimal;
                string testString;
                switch( i % 2  )
                {
                    case 0:
                        testDecimal = i / ( decimal ).32;
                        testString = i.ToString();
                        break;
                    default:
                        testDecimal = null;
                        testString = null;
                        break;
                }
                Console.WriteLine( "Loop {0}: testDecimal={1} - testString={2}", i, testDecimal , testString );
            }
        }
    }
