    [Serializable]
    public class MyAOPThing : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Console.WriteLine("OnInvoke! before");
            args.Proceed();
            Console.WriteLine("OnInvoke! after");
        }
    }
