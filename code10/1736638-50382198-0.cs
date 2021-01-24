    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestProgram
    {
        class Program
        {
            public static void Main()
            {
                var authorList = new List<Author>
                {
                    new Author() {Id = 3},
                    new Author() {Id = 4},
                    new Author() {Id = 5}
                };
    
                var postList = new List<Post>
                {
                    new Post() {AuthorId = 1},
                    new Post() {AuthorId = 1},
                    new Post() {AuthorId = 3},
                    new Post() {AuthorId = 3},
                    new Post() {AuthorId = 4},
                    new Post() {AuthorId = 6}
                };
    
                var e = (from p in postList
                         from a in authorList
                         where p.AuthorId == a.Id
                         select new { p, a });
    
                var f = authorList.Join(postList, z => z.Id, y => y.AuthorId, (a, p) => new { p, a });
    
                Console.WriteLine(e.SequenceEqual(f));
                Console.ReadLine();
            }
        }
    }
