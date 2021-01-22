    public class Foo
    {
        public string Name { get; set; }
        public void SerializeWithMetadata(Bar bar)
        {
           var obj = new {
                           Name = this.Name,
                           Guid = bar.Guid,
                           Property1 = Bar.Property1
                          }
           //Serialization code goes here
        }
    }
    
    public class Bar
    {
        public Guid Id { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
    }
