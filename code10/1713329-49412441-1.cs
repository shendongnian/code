    public class Publication
    {
        public List<string> Authors { get; set; }
        public string Title { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            IEnumerable<Publication> publications; // YOUR DATA HERE!
            var groupsByAuthor = publications.SelectMany(publication => publication.Authors.Select(author => new { Publication = publication, Author = author })).GroupBy(x => x.Author);
            foreach (var gba in groupsByAuthor)
            {
                Console.WriteLine(gba.Key);
                foreach (var pub in gba)
                {
                    Console.WriteLine(pub.Publication.Title);
                }
            }
            
            Console.ReadLine();
        }
    }
