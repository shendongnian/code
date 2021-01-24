    [PSerializable]
    public class RequiredProviderAttribute : MethodLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            MethodBase targetMethod = (MethodBase) targetElement;
            ObjectConstruction contract = new ObjectConstruction(typeof(RequiredAttribute));
            foreach (var parameterInfo in targetMethod.GetParameters())
            {
                yield return new AspectInstance(parameterInfo, contract);
            }
        }
    }
    [RequiredProvider(AttributeTargetMemberAttributes = MulticastAttributes.Public)]
    public class Program
    {
        static void Main(string[] args)
        {
            Method1(null);
        }
        private static void Method1(object a)
        {
            Method2(a);
        }
        // Contract is applied to the parameter of this method
        public static void Method2(object a)
        {
        }
    }
