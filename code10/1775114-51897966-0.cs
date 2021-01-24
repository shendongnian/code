    public class SearchResultViewModel
      {
        public IList<string> Elements { get; set; }
        public long SomeNumber { get; set; }
       
        public static explicit operator SearchResultViewModel((List<string> elements, int someNumber) tuple)
        {
          return new SearchResultViewModel()
          {
            Elements = tuple.elements,
            SomeNumber = tuple.someNumber
          };
        }
      }
