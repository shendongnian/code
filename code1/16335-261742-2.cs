    protected static void FigureItOut<TClass, TMember>(TClass source, Expression<Func<TClass, TMember>> expr)
    {
    }
    public void TestMethod()
    {
        FigureItOut(this, c => c.Name);
    }
