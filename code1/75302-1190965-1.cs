    [ServiceContract]class MathService
    {
        [OperationContract]
        public double Add(double A, double B) { return A + B; } 
        // notice the body of the method is filled in between the curly braces
        [OperationContract]
        public double Multiply (double A, double B) { return A * B; }
    }
