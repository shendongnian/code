    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Author
        {
            public string Firstname;
            public string Lastname;
            public int no;
        }
        
    class Program
    {
        private static bool isEven(int i) 
        { 
            return ((i % 2) == 0); 
        } 
        
        static void Main()
        {    
            var authorsList = new List<Author>()
            {
                new Author{ Firstname = "Bob", Lastname = "Smith", no = 2 },
                new Author{ Firstname = "Fred", Lastname = "Jones", no = 3 },
                new Author{ Firstname = "Brian", Lastname = "Brains", no = 4 },
                new Author{ Firstname = "Billy", Lastname = "TheKid", no = 1 }
            };
 
            authorsList.RemoveAll(item => isEven(item.no));
            foreach(var auth in authorsList)
            {
                Console.WriteLine(auth.Firstname + " " + auth.Lastname);
            }
        }
    }
