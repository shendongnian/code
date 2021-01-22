    public interface IAction {}
    public abstract class ActionBase : IAction {}
    public class SimpleAction : ActionBase {}
    public class ComplexAction : ActionBase {}
    [XmlArray("Actions")]
    [XmlArrayItem(typeof(SimpleAction)),XmlArrayItem(typeof(ComplexAction))]
    public List<ActionBase> Actions { get; set; }
