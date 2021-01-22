    using FinMath.LeastSquares;
    using FinMath.LinearAlgebra;
    
    Vector y = new Vector(new double[]{745,
    	895,
    	442,
    	440,
    	1598});
    
    Matrix X = new Matrix(new double[,]{
    	{1, 36, 66},
    	{1, 37, 68},
    	{1, 47, 64},
    	{1, 32, 53},
    	{1, 1, 101}});
    
    Vector b = OrdinaryLS.FitOLS(X, y);
    
    Console.WriteLine(b);
