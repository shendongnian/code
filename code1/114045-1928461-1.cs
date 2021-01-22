    [AttributeUsage (AttributeTargets.Interface)]
    public class ErrorPolicyBehaviorAttribute : Attribute, IContractBehavior, IErrorHandler
        {
        private ILog m_logger;
        #region IErrorHandler
        public void ProvideFault (Exception error, MessageVersion version, ref Message fault)
            {
            return;
            }
        public bool HandleError (Exception error)
            {
            m_logger.Error (error.Message, error);
            return true;
            }
        #endregion
        #region IContractBehavior
        public void ApplyDispatchBehavior (ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
            {
            ...init logger
            ......Add this class to a list of dispatchRuntime.ChannelDispatcher.ErrorHandlers...
            }
        #endregion
        }
