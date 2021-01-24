    using Google.Cloud.Datastore.V1;
    using System;
    using static Google.Cloud.Datastore.V1.Key.Types;
    
    static class KeyExtensions
    {
        // Useful extension method to create an incomplete "child" key
        public static Key WithIncompleteElement(this Key key, string kind)
        {
            Key ret = key.Clone();
            ret.Path.Add(new PathElement { Kind = kind });
            return ret;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string projectId = "YOUR-PROJECT-ID-HERE";
            DatastoreDb client = DatastoreDb.Create(projectId);
    
            Entity shelf = new Entity
            {
                Key = client.CreateKeyFactory("shelf").CreateIncompleteKey(),
                ["genre"] = "fiction"
            };
            Key shelfKey = client.Insert(shelf);
     
            // Insert a book specifying a complete key
            Entity book1 = new Entity
            {
                Key = shelfKey.WithElement("book", "potter1"),
                ["title"] = "Harry Potter and the Philosopher's Stone"
            };
            Key book1Key = client.Insert(book1);
            // Insert a book by creating an incomplete key with the extension method
            Entity book2 = new Entity
            {
                Key = shelfKey.WithIncompleteElement("book"),
                ["title"] = "Harry Potter and the Chamber of Secrets"
            };
            Key book2Key = client.Insert(book2);
            Console.WriteLine($"Inserted key: {book2Key}");
    
            // Insert a book by creating an incomplete key with a KeyFactory
            KeyFactory keyFactory = new KeyFactory(shelf, "book");
            Entity book3 = new Entity
            {
                Key = keyFactory.CreateIncompleteKey(),
                ["title"] = "Harry Potter and the Prisoner of Azkaban"
            };
            Key book3Key = client.Insert(book3);
            Console.WriteLine($"Inserted key: {book3Key}");    
            Console.WriteLine();
            // List all the books    
            var books = client.RunQuery(new Query { Kind = { new KindExpression { Name = "book" } } });
            Console.WriteLine("All books:");
            foreach (var book in books.Entities)
            {
                Console.WriteLine($"{(string) book["title"]}: Key={book.Key}");
            }
        }
    }
