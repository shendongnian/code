    using System;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine(MACify("00E0EE00EE00"));
        }
        
        static string MACify(string input)
        {
            var builder = new StringBuilder(input);
            for(int i=builder.Length-2; i>0; i-=2)
            {
                builder.Insert(i,':');
            }
            
            return builder.ToString();
        }
    }
