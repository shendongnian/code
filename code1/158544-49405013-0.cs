    double[] xdata = new double[] { 10, 20, 30 };
    double[] ydata = new double[] { 15, 20, 25 };
    Tuple"<"double, double">" p = Fit.Line(xdata, ydata);
    double a = p.Item1; // == 10; intercept
    double b = p.Item2; // == 0.5; slope
