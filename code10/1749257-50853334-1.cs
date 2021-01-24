    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace ConsoleApp5
    {
    class Book
    {
        public string Name;
        public DateTime Date;
        public Book(string bookName, DateTime dateAsDate)
        {
            this.Name = bookName;
            this.Date = dateAsDate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nameAndDate = new Dictionary<string, Book> {
                {"HP1", new Book("HP1", new DateTime(1997,6,26)) },
                {"HP7", new Book("HP1", new DateTime(2007,7,21)) },
                {"AC", new Book("AC", new DateTime(2009,11,20)) },
            };
            foreach (var book in nameAndDate.OrderBy(b => b.Value.Date).ThenBy(b => b.Value.Name))
            {
                Console.WriteLine($"{book.Key} -> {book.Value.Date.ToString("dd.MM.yyyy")}");
            }
            Console.ReadKey();
        }
    }
    }
