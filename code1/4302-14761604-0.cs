    var interpreter = new Interpreter()
                    .SetVariable("service", new ServiceExample());
     
    string expression = "x > 4 ? service.aMethod() : service.AnotherMethod()";
     
    Lambda parsedExpression = interpreter.Parse(expression, 
                            new Parameter("x", typeof(int)));
     
    parsedExpression.Invoke(5);
