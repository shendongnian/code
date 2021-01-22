    double[] score1 = new double[] { 12.2, 13.3, 5, 17.2, 2.2, 4.5 };
    double[] score2 = new double[] { 2.2, 4.5, 5, 12.2, 13.3, 17.2 };
    
    bool isordered1 = score1.Aggregate(double.MinValue,(accum,elem)=>elem>=accum?elem:double.MaxValue) < double.MaxValue;
    bool isordered2 = score2.Aggregate(double.MinValue,(accum,elem)=>elem>=accum?elem:double.MaxValue) < double.MaxValue;
    
    Console.WriteLine ("isordered1 {0}",isordered1);
    Console.WriteLine ("isordered2 {0}",isordered2);
