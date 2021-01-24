      public class Foo
      {
        public int ID { get; set; }
        public string Name { get; set; }
      }
    
      public class Bar
      {
        public int ID { get; set; }
        public string Name { get; set; }
      }
    
      public class FooBar
      {
        public Foo Foo { get; set; }
        public Bar Bar { get; set; }
      }
