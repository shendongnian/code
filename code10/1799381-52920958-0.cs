    public MathNet.Numerics.LinearAlgebra.Double.DenseVector 
    Diff(MathNet.Numerics.LinearAlgebra.Double.DenseVector X)
    {
        var R = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(X.Count - 2);
        for (var i = 0; i <= X.Count - 2; i++)
            R(i) = X(i + 1) - X(i);
        return R;
    }
