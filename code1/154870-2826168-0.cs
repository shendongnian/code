    public class AbstractThing {
       public String GetDescription() {
          return "This is " + GetName();
       }
       public Action<String> GetName { get; set; }
    }
    var thing = new AbstractThing();
    thing.GetName = () => "Some Name"; // Or any other method
    thing.GetDescription() == "This is Some Name";
