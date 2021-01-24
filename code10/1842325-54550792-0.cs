    public interface ISomething<T, K>
      {
        List<T> ListA { get; set; }
        List<K> ListB { get; set; }
      }
    
      public class Something01 : ISomething<string, Person>
      {
        public List<string> ListA { get; set; }
        public List<Person> ListB { get; set; }
      }
