    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method | MulticastTargets.Class,
                             AllowMultiple = true,
                             TargetMemberAttributes = MulticastAttributes.Public | 
                                                      MulticastAttributes.NonAbstract | 
                                                      MulticastAttributes.Managed)]
    class MyAspect : OnMethodInvocationAspect
    {
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            Console.WriteLine("Hello, i'm modified method");
            base.OnInvocation(eventArgs);
        }
    }
