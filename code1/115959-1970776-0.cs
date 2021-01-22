    public struct FilmYear
    {
       private int yr;
       private bool isDef;
       public bool HasValue { return isDef; }
       public bool IsNull { return !HasValue; }
       private FilmYear(int year) { yr = year; isDef = true; }
     
       public static FilmYear ThisYear = new FilmYear(DateTime.Today.Year);
       public static FilmYear LastYear = new FilmYear(DateTime.Today.Year - 1);
       public static FilmYear NextYear = new FilmYear(DateTime.Today.Year + 1);
       public static FilmYear Parse(DateTime anyDateInYear)
       { return  new FilmYear(anyDateInYear.Year); }
       public static FilmYear Parse(int year)
       { return  new FilmYear(year); }
       public static FilmYear Parse(string year)
       { return  new FilmYear(Int32.parse(year)); }
       etc... 
    }
