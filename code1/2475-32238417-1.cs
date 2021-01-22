    class MethodLogInterceptor: RealProxy
    {
         public MethodLogInterceptor(Type interfaceType, object decorated) 
             : base(interfaceType)
         {
              _decorated = decorated;
         }
         
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase;
            Console.WriteLine("Precall " + methodInfo.Name);
            var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
            Console.WriteLine("Postcall " + methodInfo.Name);
            return new ReturnMessage(result, null, 0,
                methodCall.LogicalCallContext, methodCall);
        }
    }
