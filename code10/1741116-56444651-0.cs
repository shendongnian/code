csharp
using System;
using System.Linq;
using MongoDB.Entities;
using MongoDB.Driver.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Author : Entity
        {
            public string Name { get; set; }
            public Many<Book> Books { get; set; }
            public Author() => this.InitOneToMany(() => Books);
        }
        public class Book : Entity
        {
            public string Title { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            var book = new Book { Title = "The Power Of Now" };
            book.Save();
            var author = new Author { Name = "Eckhart Tolle" };
            author.Save();
            author.Books.Add(book);
            //build a query for finding all books that has Power in the title.
            var bookQuery = DB.Queryable<Book>()
                              .Where(b => b.Title.Contains("Power"));
            //find all the authors of books that has a title with Power in them
            var authors = author.Books
                                .ParentsQueryable<Author>(bookQuery); //also can pass in an ID or array of IDs
            //get the result
            var result = authors.ToArray();
            //output the aggregation pipeline
            Console.WriteLine(authors.ToString());
            
            Console.ReadKey();
        }
    }
}
