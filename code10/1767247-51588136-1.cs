    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            string str;
            string[] newstr;
            Console.WriteLine("Enter the email addresses: ");
            str = Console.ReadLine();
            newstr = str.Split(new char[] { ',', ';' })
                .Select(s => s.Substring(0, s.IndexOf('@')));
            foreach (string s in newstr)
            {
                Console.WriteLine(s);
            }
        }
    }
