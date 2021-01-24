    using System; 
    using System.Collections.Generic; 
    using System.Xml; 
    using System.Linq; 
    namespace XXSlutuppgift_Movie 
    { 
        class Program 
        {
            static void Main(string[] args)
            {
                List<Movie> movieCollection = GetMovieCollection();
                List<Movie> Orderedlist = movieCollection.OrderBy(Film => Film.name).ToList();
                List<Movie> Top20MovieRating = movieCollection.OrderBy(Film => Film.rating).ToList();
                List<Movie> MovieYear = movieCollection.OrderBy(Film => Film.year).ToList();
                List<Movie> LetterSearch = movieCollection.OrderBy(Film => Film.name).ToList();
            }
                
            static List<Movie> GetMovieCollection() 
            { 
                List<Movie> list = new List<Movie>(); 
                XmlDocument doc = new XmlDocument(); 
                doc.Load(System.Environment.CurrentDirectory + "/moviecollection.xml"); 
                XmlNode node = doc.DocumentElement.SelectSingleNode("/MovieCollection/Movies"); 
                foreach(XmlNode row in node.ChildNodes) 
                { 
                    Movie item = new Movie(); 
                    item.id = Int32.Parse(row.SelectSingleNode("Id").InnerText); 
                    item.name = row.SelectSingleNode("Name").InnerText; 
                    item.rating = Double.Parse(row.SelectSingleNode("Rating").InnerText.Replace(".", ",")); 
                    item.votes = Int32.Parse(row.SelectSingleNode("Votes").InnerText); 
                    item.year = Int32.Parse(row.SelectSingleNode("Year").InnerText); 
                    list.Add(item); 
                } return list; 
            } 
        }
        public class Movie
        {
            public int id { get;set;}
            public string name { get;set;}
            public double rating { get;set;}
            public int votes { get;set;}
            public int year { get;set;}
        }
    }
