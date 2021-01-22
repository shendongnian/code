    [TestMethod]
    public void BasicSymbolicTest()
    {
        ParameterExpression x = Expression.Parameter(typeof(double), "x");
        Expression linear = Expression.Add(Expression.Constant(3.0), x);
        Assert.AreEqual("(+ 3 x)", Symbolic.ToString(linear));
        Expression quadratic = Expression.Multiply(linear, Expression.Add(Expression.Constant(2.0), x));
        Assert.AreEqual("(* (+ 3 x) (+ 2 x))", Symbolic.ToString(quadratic));
        Expression expanded = Symbolic.Expand(quadratic);
        Assert.AreEqual("(+ (+ (+ (* 3 2) (* 3 x)) (* x 2)) (* x x))", Symbolic.ToString(expanded));
        Assert.AreEqual("(+ (+ (+ 6 (* 3 x)) (* x 2)) (* x x))", Symbolic.ToString(Symbolic.Simplify(expanded)));
        Expression derivative = Symbolic.PartialDerivative(expanded, x);
        Assert.AreEqual("(+ (+ (+ (+ (* 3 0) (* 0 2)) (+ (* 3 1) (* 0 x))) (+ (* x 0) (* 1 2))) (+ (* x 1) (* 1 x)))", Symbolic.ToString(derivative));
        Expression simplified = Symbolic.Simplify(derivative);
        Assert.AreEqual("(+ 5 (+ x x))", Symbolic.ToString(simplified));
    }
