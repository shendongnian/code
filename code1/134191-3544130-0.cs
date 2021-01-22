    public class ConcreteContainer : IContainer
    {
        // This is the property that will be seen by code that accesses
        // this instance through a variable of this type (ConcreteContainer)
        public EntityCollection<ConcreteChild> Children { get; set; }           
        // This is the property that will be used by code that accesses
        // this instance through a variable of the type IContainer
        IEnumerable<ConcreteChild> IContainer.Children {
            get { return Children; }
            set {
                var newCollection = new EntityCollection<ConcreteChild>();
                foreach (var item in value)
                    newCollection.Add(item);
                Children = newCollection;
            }
        }
    }
