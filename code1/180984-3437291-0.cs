    using System;
    
    class Test
    {
        static void permute(int len)
        {
            for (int i=1; i<=len; i++) 
            {
                for (int j=0; j<Math.Pow(2, i); j++)
                {
                    Console.WriteLine (Convert.ToString(j, 2).PadLeft(i, '0'));
                }
    	    }
        }
    }
