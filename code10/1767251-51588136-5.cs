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
            newstr = str.Split(new char[] { ',', ';' })  // Split to get a array of addresses to work with
                .Select(s => s.Substring(0, s.IndexOf('@'))).ToArray(); // Extract the sender from the email addresses
            foreach (string s in newstr)
            {
                Console.WriteLine(s);
            }
        }
    }
