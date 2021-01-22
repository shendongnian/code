    public enum InvocationType { Event }
    public class CustomProxy<T> : RealProxy {
        private List<string> invocations = new List<string>();
        private InvocationType invocationType;
        public CustomProxy(InvocationType invocationType) : base(typeof(T)) {
            this.invocations = new List<string>();
            this.invocationType = invocationType;
        }
        public List<string> Invocations {
            get { 
                return invocations; 
            }
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        [DebuggerStepThrough]
        public override IMessage Invoke(IMessage msg) {
            String methodName = (String) msg.Properties["__MethodName"];
            Type[] parameterTypes = (Type[]) msg.Properties["__MethodSignature"];
            MethodBase method = typeof(T).GetMethod(methodName, parameterTypes);
            switch (invocationType) {
                case InvocationType.Event:
                    invocations.Add(ReplaceAddRemovePrefixes(method.Name));
                    break;
                // You could deal with other cases here if needed
            }
            IMethodCallMessage message = msg as IMethodCallMessage;
            Object response = null;
            ReturnMessage responseMessage = new ReturnMessage(response, null, 0, null, message);
            return responseMessage;
        }
        private string ReplaceAddRemovePrefixes(string method) {
            if (method.Contains("add_"))
                return method.Replace("add_","");
            if (method.Contains("remove_"))
                return method.Replace("remove_","");
            return method;
        }
    }
