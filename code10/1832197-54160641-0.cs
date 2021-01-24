    using System;
    using System.Collections.Generic;
    using System.IO;
    class Solution 
    {
        static void Main(String[] args) 
        {   
            var phoneBook = new Dictionary<string, string>();
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] record = Console.ReadLine().Split();
                string name = record[0];
                string phoneNumber = record[1];
                phoneBook.Add(name, phoneNumber); 
            }
            string x;
            while((x = Console.ReadLine()) != null)
            {
                if(phoneBook.ContainsKey(x))
                {
                    Console.WriteLine(x + "=" + phoneBook[x]);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }
    }
