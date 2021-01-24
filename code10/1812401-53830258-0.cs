    [Serializable, AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class TestClassAttribute : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Type type = (Type)targetElement;
            return type.GetMethods().Where(method => method.GetCustomAttributes(typeof(AttributeA), false)
                    .Any()).Select(m => new AspectInstance(m, new CustomAttributeIntroductionAspect(
                        new ObjectConstruction(typeof(AttributeB).GetConstructor(Type.EmptyTypes)))));
        }
    }
