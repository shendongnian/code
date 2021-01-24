    ExpressionContext context = new ExpressionContext();
    VariableCollection variables = context.Variables;
    variables.Add("a", 100);
    variables.Add("b", 1);
    variables.Add("c", 24);
                
    IGenericExpression<bool> e = context.CompileGeneric<bool>("(a = 100 OR b > 0) AND c <> 2");
    bool result = e.Evaluate();
