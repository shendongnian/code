    public Operand ExpressionTree
    {
        get;
        private set;
    }
    
    private Stack<Operands.Operand> stack = new Stack<InfixParser.Operands.Operand>();
    private Queue<Operands.Operand> outputQueue = new Queue<InfixParser.Operands.Operand>();
    
    private void ParseFormulaString()
    {
        //Dijkstra's Shunting Yard Algorithm
        Regex re = new Regex(@"([\+\-\*\(\)\^\/\ ])");
        List<String> tokenList = re.Split(formulaString).Select(t => t.Trim()).Where(t => t != "").ToList();
    
        for (int tokenNumber = 0; tokenNumber < tokenList.Count(); ++tokenNumber)
        {
            String token = tokenList[tokenNumber];
            TokenClass tokenClass = GetTokenClass(token);
    
            switch (tokenClass)
            {
                case TokenClass.Value:
                    outputQueue.Enqueue(new Value(token));
                    break;
                case TokenClass.Function:
                    stack.Push(new Function(token, 1));
                    break;
                case TokenClass.Operator:
                    if (token == "-" && (stack.Count == 0 || tokenList[tokenNumber - 1] == "("))
                    {
                        //Push unary operator 'Negative' to stack
                        stack.Push(new Negative());
                        break;
                    }
                    if (stack.Count > 0)
                    {
                        String stackTopToken = stack.Peek().Token;
                        if (GetTokenClass(stackTopToken) == TokenClass.Operator)
                        {
                            Associativity tokenAssociativity = GetOperatorAssociativity(token);
                            int tokenPrecedence = GetOperatorPrecedence(token);
                            int stackTopPrecedence = GetOperatorPrecedence(stackTopToken);
    
                            if (tokenAssociativity == Associativity.Left && tokenPrecedence <= stackTopPrecedence ||
                                tokenAssociativity == Associativity.Right && tokenPrecedence < stackTopPrecedence)
                            {
                                outputQueue.Enqueue(stack.Pop());
                            }
                        }
                    }
                    stack.Push(new BinaryOperator(token, Operator.OperatorNotation.Infix));
                    break;
                case TokenClass.LeftParen:
                    stack.Push(new LeftParenthesis());
                    break;
                case TokenClass.RightParen:
                    while (!(stack.Peek() is LeftParenthesis))
                    {
                        outputQueue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
    
                    if (stack.Count > 0 && stack.Peek() is Function)
                    {
                        outputQueue.Enqueue(stack.Pop());
                    }
                    break;
            }
    
            if (tokenClass == TokenClass.Value || tokenClass == TokenClass.RightParen)
            {
                if (tokenNumber < tokenList.Count() - 1)
                {
                    String nextToken = tokenList[tokenNumber + 1];
                    TokenClass nextTokenClass = GetTokenClass(nextToken);
                    if (nextTokenClass != TokenClass.Operator && nextTokenClass != TokenClass.RightParen)
                    {
                        tokenList.Insert(tokenNumber + 1, "*");
                    }
                }
            }
        }
    
        while (stack.Count > 0)
        {
            Operand operand = stack.Pop();
            if (operand is LeftParenthesis || operand is RightParenthesis)
            {
                throw new ArgumentException("Mismatched parentheses");
            }
    
            outputQueue.Enqueue(operand);
        }
    
        String foo = String.Join(",", outputQueue.Select(t => t.Token).ToArray());
        String bar = String.Join("", tokenList.ToArray());
    
        Stack<Operand> expressionStack = new Stack<Operand>();
        while (outputQueue.Count > 0)
        {
            Operand operand = outputQueue.Dequeue();
    
            if (operand is Value)
            {
                expressionStack.Push(operand);
            }
            else
            {
                if (operand is BinaryOperator)
                {
                    BinaryOperator op = (BinaryOperator)operand;
                    Operand rightOperand = expressionStack.Pop();
                    Operand leftOperand = expressionStack.Pop();
                    op.LeftOperand = leftOperand;
                    op.RightOperand = rightOperand;
                }
                else if (operand is UnaryOperator)
                {
                    ((UnaryOperator)operand).Operand = expressionStack.Pop();
                }
                else if (operand is Function)
                {
                    Function function = (Function)operand;
                    for (int argNum = 0; argNum < function.NumArguments; ++argNum)
                    {
                        function.Arguments.Add(expressionStack.Pop());
                    }
                }
    
                expressionStack.Push(operand);
            }
        }
    
        if (expressionStack.Count != 1)
        {
            throw new ArgumentException("Invalid formula");
        }
    
        ExpressionTree = expressionStack.Pop();
    }
    
    private TokenClass GetTokenClass(String token)
    {
        double tempValue;
        if (double.TryParse(token, out tempValue) ||
            token.Equals("R", StringComparison.CurrentCultureIgnoreCase) ||
            token.Equals("S", StringComparison.CurrentCultureIgnoreCase))
        {
            return TokenClass.Value;
        }
        else if (token.Equals("sqrt", StringComparison.CurrentCultureIgnoreCase))
        {
            return TokenClass.Function;
        }
        else if (token == "(")
        {
            return TokenClass.LeftParen;
        }
        else if (token == ")")
        {
            return TokenClass.RightParen;
        }
        else if (binaryInfixOperators.Contains(token))
        {
            return TokenClass.Operator;
        }
        else
        {
            throw new ArgumentException("Invalid token");
        }
    }
    
    private Associativity GetOperatorAssociativity(String token)
    {
        if (token == "^")
            return Associativity.Right;
        else
            return Associativity.Left;
    }
    
    private int GetOperatorPrecedence(String token)
    {
        if (token == "+" || token == "-")
        {
            return 1;
        }
        else if (token == "*" || token == "/")
        {
            return 2;
        }
        else if (token == "^")
        {
            return 3;
        }
        else
        {
            throw new ArgumentException("Invalid token");
        }
    }
