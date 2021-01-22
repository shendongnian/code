    public interface IParent
    {
        IList<Child> children { get; set; }
        void AddChild(Child child);
        Int64 Id { get; set; }
        Child GetChild();
    }
    public class Parent : IParent
    {
        public virtual IList<Child> children { get; set; }
        
        public Parent()
        {
            children = new List<Child>();
        }
        public virtual void AddChild(Child child)
        {
            children.Add( new Child() );
        }
        public virtual Int64 Id { get; set; }
        public virtual Child GetChild()
        {
            return children.First();
        }
    }
    public class Parent2 : IParent
    {
        public virtual IList<Child> children { get; set; }
        public Parent2()
        {
            children = new List<Child>();
        }
        public virtual void AddChild(Child child)
        {
            children.Add(new Child());
        }
        public virtual Int64 Id { get; set; }
        public virtual Child GetChild()
        {
            return children.First();
        }
    }
    public class Child
    {
        public virtual Int64 Id { get; private set; }
    }
