    namespace HelloWorld
    {
        class Hello
        {
            static void Main()
            {
    
                List<Author> AuthorList = new List<Author>
                {
                    new Author(1, false),
                    new Author(2, false),
                    new Author(3, false)
                };
    
    
                List<Author> AuthorList2 = new List<Author>
                {
                    new Author(1, false)
                };
    
                AuthorList.ForEach(a => a.Assigned = AuthorList2.Exists(b => b.ProductId == a.ProductId));
    
                foreach (var item in AuthorList)
                {
                    Console.WriteLine("Result: {0},{1}", item.ProductId, item.Assigned);
                }
    
                Console.ReadKey();
            }
            
            public class Author
            {
                public Author(int productId, bool assigned)
                {
                    this.ProductId = productId;
                    this.Assigned = assigned;
                }
    
                public int ProductId { get; set; }
    
                public bool Assigned { get; set; }
            }
        }
    }
