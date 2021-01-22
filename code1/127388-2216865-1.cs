    public class BindingDefinition
    {
        public BindingDefinition(
            InterfaceTypeDefinition definition, Type openGenericType)
        {
            Implementation = definition.Implementation;
            Service = definition.GetService(openGenericType);
        }
        public Type Implementation { get; private set; }
        public Type Service { get; private set; }
    }
