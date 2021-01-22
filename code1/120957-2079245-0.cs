    public class HelloService : IHelloService
    {
        [OperationBehavior]
        public string Hello(string message)
        {
            WindowsIdentity callerWindowsIdentity =
            ServiceSecurityContext.Current.WindowsIdentity;
            if (callerWindowsIdentity == null)
            {
                throw new InvalidOperationException
                ("The caller cannot be mapped to a WindowsIdentity");
            }
            using (callerWindowsIdentity.Impersonate())
            {
               // Access a file as the caller.
            }
            return "Hello";
        }
    }
