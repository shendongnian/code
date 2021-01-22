    // Define the IMath contract.
    [ServiceContract]
    public interface IMath
    {
        [OperationContract] 
        double Add(double A, double B);
        [OperationContract]
        double Multiply (double A, double B);
    }
    // Implement the IMath contract in the MathService class.
    public class MathService : IMath
    {
        public double Add (double A, double B) { return A + B; }
        public double Multiply (double A, double B) { return A * B; }
    }
