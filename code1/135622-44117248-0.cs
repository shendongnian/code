        public interface ILongOperationCallBack
        { 
            [OperationContract(IsOneWay = true)]
            void OnResultsSend(....);        
        }
