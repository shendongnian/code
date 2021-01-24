    using System;
    namespace InterpreterStateMachine.Contracts
    {
        public interface IValidationNeeded
        {
            Guid RequestId { get; }
            Request Request { get; }
        }
    }
