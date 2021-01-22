       public class A
       {
          public string Title { get; set; }
    
          [TypeConverter(typeof(BStringConvertor))]
          public B BField { get; set; }
       }
    
       public class B
       {
          public string Title { get; set; }
          
          public override string ToString()
          {
             return this.Title;
          }
       }
