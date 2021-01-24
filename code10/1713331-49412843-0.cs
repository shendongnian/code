    class Program
    {
        static void Main(string[] args)
        {
            List<Publication> test = new List<Publication>();
            Dictionary<string, List<Publication>> publicationsByAuther = test.GroupByAuthor();
        }
    }
    public static class Extensions
    {
        public static Dictionary<string, List<Publication>> GroupByAuther(this List<Publication> publications)
        {
            Dictionary<string, List<Publication>> dict = new Dictionary<string, List<Publication>>();
            foreach (var publication in publications)
            {
                foreach (var author in publication.Authors)
                {
                    if (dict.ContainsKey(author))
                    {
                        dict[author].Add(publication);
                    }
                    else
                    {
                        dict.Add(author, new List<Publication>
                    {
                        publication
                    });
                    }
                }
            }
            return dict;
        }
    }
