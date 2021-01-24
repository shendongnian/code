    public class Component 
    {
        public Component() 
        {
            SystemComponents = new Collection<SystemComponent>();
            ChildComponents = new Collection<ComponentComponent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        // Needs this for the Many to Many relationship
        public virtual ICollection<SystemComponent> SystemComponents { get; set; }
        // Any component can contain one or more existing components
        public virtual ICollection<ComponentComponent> ChildComponents { get; set; }
    }
