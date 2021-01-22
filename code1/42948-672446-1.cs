    public class ContainerVisitor : INodeVisitor
    {
        public void VisitContainer(IContainer container)
        {
            foreach (IComponent component in container.Components)
            {
                // ...
            }
        }
    }
