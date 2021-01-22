    public interface IBehavior
    {
        ... common behavior methods like maybe
        bool Execute(object value)
    }
    public class Taggable : IBehavior
    {
       ... tag specific items
       public bool Execute(object value) { ... }
    }
    public class Note
    {
       public List<IBehavior> Behaviors { get; set; }
       public void ProcessNote()
       {
           this.Behaviors(d=>d.Execute(this));
       }
    }
