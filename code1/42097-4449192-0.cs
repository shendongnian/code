    public string EvalAmount(string expression)
    {
        double? dbl = this.Eval(expression) as double?;
        return dbl.HasValue ? string.Format("{0:0.0}", (dbl.Value / 1000000D)) : string.Empty;
    }
