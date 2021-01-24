    using System;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            string str;
            string[] newstr;
            Console.WriteLine("Enter the email addresses: ");
            str = Console.ReadLine();
            newstr = str.Split(new char[] { ',', ';' }); // Split to get a temporal array of addresses 
            foreach (string s in newstr)
            {
                Console.WriteLine(s.Substring(0, s.IndexOf('@'))); // Extract the sender from the email addresses
            }
        }
    }
