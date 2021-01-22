    public class MyWrapper
    {
         public MyWrapper(SourceObject sourceObject)
         {
             this.Points = sourceObject.ListPoints();
         }
         [DataMember]   
         public List<decimal> Points { get; private set; }
    }
