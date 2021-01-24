    public class Movie
    {
      public string Title {get;set;}
      public decimal Gross {get;set;}
      public decimal Weekly {get;set;}
      public int Weeks {get;set;}
    }
    public void ReadMovies()
    {
      List<Movie> movies = new List<Movie>();
      string[] lines = File.ReadAllLines("movies.txt");
      int cursor = 0;
      while (cursor < lines.Length)
      {
        if (lines[cursor].Contains("$"))
        {
          movies.Add(ParseMovie(lines, ref cursor));
        }
        cursor++;
      }
    }
  
    public Movie ParseMovie(string[] lines, ref int cursor)
    {
      Movie result = new Movie();
  
      // this method is called when we reach the gross dollar figure, so 
      // we have to back up to get the title
  
      result.Title = lines[--cursor];
      // these lines assume that the parse methods will succeed; if the
      // underlying structure of the text is more uncertain, these should be
      // replaced with the 'TryParse' pattern
      result.Gross = decimal.Parse(lines[++cursor].Trim('$', 'M'));
      result.Weekly = decimal.Parse(lines[++cursor].Trim('$', 'M'));
      result.Weeks = int.Parse(lines[++cursor]);
  
      // we return from this method with the cursor on the last line
      // of the movie entry -- this will be incremented when we return
      // in the ReadMovies method
  
      return result;
    }
