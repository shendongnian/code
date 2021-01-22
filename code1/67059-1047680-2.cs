    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace CSV
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                string csv = "user1, user2, user3,user4,user5";
                
                string[] split = csv.Split(new char[] {',',' '});
                foreach(string s in split)
                {
                    if (s.Trim() != "")
                        Console.WriteLine(s);
                }
                Console.ReadLine();
            }
        }
    }
            
