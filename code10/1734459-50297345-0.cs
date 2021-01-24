    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleAppTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var artists = new List<Artist>();
                artists.Add(new Artist { Name = "Pearl Jam", Genre = "ROCK" });
                artists.Add(new Artist { Name = "Beyonce", Genre = "POP" });
                if (HasNonRockArtists(artists)) Console.WriteLine("The list contains non-rock artists.");
                Console.ReadLine();
            }
    
            private static string[] genres = new string[] { "HIP HOP", "POP" };
            private static bool HasNonRockArtists(List<Artist> artists)
            {
                return artists.Any(a => genres.Contains(a.Genre));
            }
            public class Artist
            {
                public string Name { get; set; }
                public string Genre { get; set; }
            }
        }
    }
