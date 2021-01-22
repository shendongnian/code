      public class FooMap : ClassMap<Foo>
      {
        public FooMap()
        {
          Id(x => x.Id);
          References<Bar>(x => x.Bar).Cascade.All();
        }
      }
    
      public class BarMap : ClassMap<Bar>
      {
        public BarMap()
        {
          Id(x => x.Id);
          Map(x => x.Text);
        }
      }
