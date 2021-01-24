      // for demo purposes I manually fill the list of tokens
      // with the tokens in order how they are output by the shunting-yard algorithm
      var tokenQueue = new Token[]
      {
        new VariableToken("A"),
        new VariableToken("B"),
        new OperatorToken("+"),
        new VariableToken("C"),
        new OperatorToken("*")
      };
      var inputParameter = Expression.Parameter(typeof(TableTest));
      var expressions = new Stack<Expression>();
      foreach (var token in tokenQueue)
      {
        // transform token to expression by using the helper methods of https://msdn.microsoft.com/de-de/library/system.linq.expressions.expression_methods(v=vs.110).aspx
        switch (token)
        {
          case VariableToken variableToken:
            // this will reference the property in your TableTest input specified by the variable name, e.g. "A" will reference TableTest.A
            expressions.Push(Expression.Property(inputParameter, variableToken.Name));
            break;
          case OperatorToken operatorToken:
            // This will take two expression from the stack, give these to input to an operator and put the result back onto the queue for use for the next operator
            var rightOperand = expressions.Pop();
            var leftOperand = expressions.Pop();
            if (operatorToken.Name == "+")
            {
              expressions.Push(Expression.Add(leftOperand, rightOperand));
            }
            else if (operatorToken.Name == "*")
            {
              expressions.Push(Expression.Multiply(leftOperand, rightOperand));
            }
            break;
        }
      }
      // create and fill output model with final expression
	  var outputModelExpr = Expression.New(typeof(OutputModel).GetConstructor(new[] {typeof(decimal) }), expressions.Single());
      // create the lambda expression 
      // in this example it will have the form: x => return new OutputModel((x.A + x.B) * x.C)
      Expression<Func<TableTest, OutputModel>> lambda = Expression.Lambda<Func<TableTest, OutputModel>>(outputModelExpr, inputParameter);
      
      // only for testing purposes: compile it to a function and run it
      var calc = lambda.Compile();
      var testInput = new TableTest { A = 1, B = 2, C = 3 };
      Console.WriteLine(calc(testInput).Result); // returns 9, because (A + B) * C = (1 + 2) * 3 = 9
