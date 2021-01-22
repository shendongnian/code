    public interface IErrorHandler
    {
        bool HandleError(Exception error, MessageFault fault);
        void ProvideFault(Exception error, ref MessageFault fault, ref string faultAction);
    }
