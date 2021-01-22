        public interface IError
        {
            string Message
            {
                [OperationContract]
                get;
                // leave unattributed
                set;
            }
        }
