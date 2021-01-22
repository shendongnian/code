        [ServiceContract(CallbackContract=typeof(ILongOperationCallBack))]
        public interface ILongOperationService
        {
            [OperationContract]
            bool StartLongOperation(...);
        }
