    using System;
    using System.Linq;
    
    class Test
    {   
        static void Main(string[] args)
        {
            ShowGroups();
        }
        
        private static readonly char[] Letters = 
            "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ0".ToCharArray();
        
        // This is taking the place of EntityBase.db.Services
        // for the purposes of the test program
        public static string[] Services = { "Blogger", "Delicious", 
                "Digg", "Ebay", "Facebook", "Feed", "Flickr", 
                "Friendfeed", "Friendster", "Furl", "Google", 
                "Gosupermodel", "Lastfm", "Linkedin", "Livejournal",
                "Magnolia", "Mixx", "Myspace", "NetOnBuy", "Netvibes",
                "Newsvine", "Picasa", "Pownce", "Reddit", "Stumbleupon",
                "Technorati", "Twitter", "Vimeo", "Webshots", 
                "Wordpress" };
    
        public static void ShowGroups()
        {
            var groupedByLetter = 
                from letter in Letters
                join service in Services on letter equals service[0] into grouped
                select new { Letter = letter, Services = grouped };
     
            // Demo of how to access the groups
            foreach (var entry in groupedByLetter)
            {
                Console.WriteLine("=== {0} ===", entry.Letter);
                foreach (var service in entry.Services)
                {
                    Console.WriteLine ("  {0}", service);
                }
                Console.WriteLine();
            }
        }
    }
