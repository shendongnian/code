    public interface ICalculatorDuplex
    {
        [OperationContract(IsOneWay = true)]
        void Clear();
        [OperationContract(IsOneWay = true)]
        void AddTo(double n);
        [OperationContract(IsOneWay = true)]
        void SubtractFrom(double n);
        [OperationContract(IsOneWay = true)]
        void MultiplyBy(double n);
        [OperationContract(IsOneWay = true)]
        void DivideBy(double n);
    }
    
    
    public interface ICalculatorDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Equals(double result);
        [OperationContract(IsOneWay = true)]
        void Equation(string eqn);
    }
