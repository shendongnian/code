    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main()
            {
                List<Book> books = new List<Book>() 
                {
                    new Book() { Id = 113421, Title = "A" },
                    new Book() { Id = 113422, Title = "B" }
                };
    
                List<Tag> tags = new List<Tag>()
                {
                    new Tag() { Id = 1, Name = "ASP" },
                    new Tag() { Id = 2, Name = "C#" },
                    new Tag() { Id = 3, Name = "CSS" },
                    new Tag() { Id = 4, Name = "VB" },
                    new Tag() { Id = 5, Name = "VB.NET" },
                    new Tag() { Id = 6, Name = "PHP" },
                    new Tag() { Id = 7, Name = "Java" },
                    new Tag() { Id = 8, Name = "Pascal" }
                };
    
                List<BookTag> booktags = new List<BookTag>()
                {
                    new BookTag() { Id = 1, BookId = 113421, TagId = 1 },
                    new BookTag() { Id = 2, BookId = 113421, TagId = 2 },
                    new BookTag() { Id = 3, BookId = 113421, TagId = 3 },
                    new BookTag() { Id = 4, BookId = 113421, TagId = 4 },
                    new BookTag() { Id = 5, BookId = 113422, TagId = 1 },
                    new BookTag() { Id = 6, BookId = 113422, TagId = 4 },
                    new BookTag() { Id = 7, BookId = 113422, TagId = 8 }
                };
    
                
                List<int> selectedTagIds = new List<int>() { 1,2 };
    
                // get applicable books based on selected tags
    
                var query = from book in books
                            join booktag in booktags
                            on book.Id equals booktag.BookId
                            join selectedId in selectedTagIds
                            on booktag.TagId equals selectedId
                            group book by book into bookgroup
                            where bookgroup.Count() == selectedTagIds.Count
                            select bookgroup.Key;
    
                foreach (Book book in query)
                {
                    Console.WriteLine("{0}\t{1}",
                        book.Id,
                        book.Title);
                }
    
                // get related tags for selected tags
    
                var relatedTags = from book in query // use original query as base
                                  join booktag in booktags
                                  on book.Id equals booktag.BookId
                                  join tag in tags
                                  on booktag.TagId equals tag.Id
                                  where !selectedTagIds.Contains(tag.Id) // exclude selected tags from related tags
                                  group tag by tag into taggroup
                                  select new
                                  {
                                      Tag = taggroup.Key,
                                      Count = taggroup.Count()
                                  };
    
                foreach (var relatedTag in relatedTags)
                {
                    Console.WriteLine("{0}\t{1}\t{2}",
                        relatedTag.Tag.Id,
                        relatedTag.Tag.Name,
                        relatedTag.Count);
                }
    
                Console.Read();
            }
        }
    
        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    
        class Tag
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        class BookTag
        {
            public int Id { get; set; }
            public int BookId { get; set; }
            public int TagId { get; set; }
        } 
    }
