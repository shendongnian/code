    public class TargetType {
      public string Prop1 {get;set;}
      public string Prop1 {get;set;}
      // Constructor
      public TargetType(OrigType origType) {
        Prop1 = origType.Prop1;
        Prop2 = origType.Prop2;
      }
    }
    var origList = new List<OrigType>();
    var targetList = origList.Select(s=> new TargetType(s)).ToList();  
