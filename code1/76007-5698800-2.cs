    public class Recording
        {
            public Recording() { 
            }
            public Recording(string artistName, string cdName, DateTime release)
            { Artist = artistName; Name = cdName; ReleaseDate = release; }
            public string Artist { get; set; }
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            // Override the ToString method.
            public override string ToString() 
            { return Name + " by " + Artist + ", Released: " + ReleaseDate.ToShortDateString();
            }
        } 
     
