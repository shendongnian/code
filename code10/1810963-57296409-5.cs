    Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,]
    {
        { 1, 2, 1 },
        { 3, 6, 3 },
        { 4, 8, 4 }
    });
    Vector<double> B = Vector<double>.Build.Dense(new double[] { 3, 9, 12 });
    foreach (var x in A.SolveDegenerate(B))
        Console.WriteLine(x);
