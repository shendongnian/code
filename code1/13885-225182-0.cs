    public class Container<T> where T : MudObject
    {
        List<T> Contains;
        MudObject containerOwner;
        public Container(MudObject owner)
        {
            containerOwner = owner;
        }
        // Other methods to handle parent association
    }
    public interface IMudContainer<T> where T : MudObject
    {
        Container<T> Contains { get; }
    }
    public class MudObjectThatContainsStuff : IMudContainer
    {
        public MudObjectThatContainsStuff()
        {
            Contains = new Container<MudObject>(this);
        }
        public Contains { get; }
    }
