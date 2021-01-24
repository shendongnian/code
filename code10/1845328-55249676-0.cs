    [Fact]
    public void ShouldActivateTypesWithInternalConstructor()
    {
        var fixture = new Fixture();
    
        fixture.ResidueCollectors.Add(
            new Postprocessor(
                new MethodInvoker(
                    new ModestInternalConstructorQuery()),
                new AutoPropertiesCommand()
            ));
        
        var result = fixture.Create<TypeWithInternalConstructor>();
    
        Assert.NotEqual(0, result.Property);
    }
    
    public class ModestInternalConstructorQuery : IMethodQuery
    {
        public IEnumerable<IMethod> SelectMethods(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
    
            return from ci in type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
                where ci.IsAssembly // Take internal constructors only
                let parameters = ci.GetParameters()
                where parameters.All(p => p.ParameterType != type)
                orderby parameters.Length ascending
                select new ConstructorMethod(ci) as IMethod;
        }
    }
    
    public class TypeWithInternalConstructor
    {
        public int Property { get; }
    
        internal TypeWithInternalConstructor(int property)
        {
            Property = property;
        }
    }
