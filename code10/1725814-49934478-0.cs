    public static void Main(string[] args)
     {
        var res = ReplaceLastOccurrence("1,2,3,4,5", ",", " and ");
         Console.WriteLine(res);
     }
    public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
      {
          int place = Source.LastIndexOf(Find);   
          if(place == -1)
            return Source;
           string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
      }
