      [ServiceContract]
      public  interface Test
     {
        [OperationContract]
        [FaultContract(typeof(CalculatorFault))]
            double add(double a, double b);
    }
