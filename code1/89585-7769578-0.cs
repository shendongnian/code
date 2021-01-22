    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace Intfix_to_Postfix
    {
        #region enums
        enum TokenTypes
        {
            Operator,
            Number,
            Parenthesis
        }
        enum Associativenesses
        {
            Left,
            Right,
            None
        }
        #endregion
    
        #region token class
        class Token
        {
            public TokenTypes TokenType { get; set; }
            public string Value { get; set; }
            public Associativenesses Associativeness
            {
                get
                {
                    if (this.TokenType != TokenTypes.Operator)
                        return Associativenesses.None;
                    else if (this.Value == "/")
                        return Associativenesses.Left;
                    else if (this.Value == "+" || this.Value == "-" || this.Value == "*")
                        return Associativenesses.Right;
                    else
                        throw new Exception("Invalid Associativeness");
                }
            }
            public int Precedence
            {
                get
                {
                    if (this.TokenType == TokenTypes.Operator)
                    {
                        if (this.Value == "*" || this.Value == "/") return 3;
                        else if (this.Value == "+" || this.Value == "-") return 4;
                        throw new Exception("Invalid Value for Precendence get");
                    }
                    else
                    {
                        throw new Exception("Invalid TokenType for Precendence get");
                    }
                }
            }
    
            public Token() { }
    
            public Token(TokenTypes type, string value) { TokenType = type; Value = value; }
    
            public override string ToString()
            {
                return Value;
            }
        }
        #endregion
    
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string Equation = "";
                    Equation = "(1+2)+3";
                    Equation = "(((12.7+2)/3)-10)*(32+(3*5))";
                    //Equation = "5 + ((1 + 2) * 4) - 3";
                    //Equation = "1 + (3 * 4) - 3";
                    //Equation = "5+8-(2*2)";
                    
                    Console.WriteLine("EQUATION: " + Equation);
    
                    Stack<Token> InFixStack = GetTokens(Equation);
                    Console.WriteLine("PARSED EQUATION: " + String.Join("", InFixStack));
    
                    #region convert to postfix
                    Stack<Token> output = new Stack<Token>();
                    Stack<Token> operators = new Stack<Token>();
                    while (InFixStack.Count > 0)
                    {
                        Token currentToken = InFixStack.Pop();
                        Console.WriteLine("TOKEN: " + currentToken);
    
                        if (currentToken.TokenType == TokenTypes.Operator)
                        {
                            while (operators.Count > 0 && operators.Peek().TokenType == TokenTypes.Operator)
                            {
                                if ((currentToken.Associativeness == Associativenesses.Left && currentToken.Precedence <= operators.Peek().Precedence)
                                    || (currentToken.Associativeness == Associativenesses.Right && currentToken.Precedence < operators.Peek().Precedence))
                                {
                                    output.Push(operators.Pop());
                                }
                                else
                                {
                                    break;
                                }
                            }
                            operators.Push(currentToken);
                        }
                        else if (currentToken.Value == "(")
                        {
                            operators.Push(currentToken);
                        }
                        else if (currentToken.Value == ")")
                        {
                            // will error here if unmatched parentheses
                            while (operators.Count > 0 && operators.Peek().Value != "(")
                            {
                                output.Push(operators.Pop());
                            }
                            operators.Pop();
                        }
                        else
                        {
                            // assume it's a number:
                            output.Push(currentToken);
                        }
                    }
    
                    while (operators.Count > 0)
                    {
                        //If the operator token on the top of the stack is a parenthesis, then there are mismatched parentheses.
                        output.Push(operators.Pop());
                    }
    
                    Stack<Token> PostFixStack = new Stack<Token>();
                    while (output.Count > 0) PostFixStack.Push(output.Pop());
                    #endregion
    
                    Console.WriteLine("POSTFIX: " + String.Join(" ", PostFixStack));
    
                    #region evaluate postfix
                    Stack<Token> EvaluationStack = new Stack<Token>();
                    while (PostFixStack.Count > 0)
                    {
                        Token currentToken = PostFixStack.Pop();
                        Console.WriteLine("EVAL: " + currentToken.Value);
    
                        if (currentToken.TokenType == TokenTypes.Number)
                        {
                            EvaluationStack.Push(currentToken);
                        }
                        else if (currentToken.TokenType == TokenTypes.Operator)
                        {
                            if (currentToken.Value == "+" || currentToken.Value == "-" || currentToken.Value == "*" || currentToken.Value == "/" )
                            {
                                string FirstValue = EvaluationStack.Pop().Value;
                                string SecondValue = EvaluationStack.Pop().Value;
                                
                                if (currentToken.Value == "+")
                                {
                                    EvaluationStack.Push(new Token(TokenTypes.Number, Convert.ToString(Convert.ToDecimal(SecondValue) + Convert.ToDecimal(FirstValue))));
                                }
                                else if (currentToken.Value == "-")
                                {
                                    EvaluationStack.Push(new Token(TokenTypes.Number, Convert.ToString(Convert.ToDecimal(SecondValue) - Convert.ToDecimal(FirstValue))));
                                }
                                else if (currentToken.Value == "/")
                                {
                                    EvaluationStack.Push(new Token(TokenTypes.Number, Convert.ToString(Convert.ToDecimal(SecondValue) / Convert.ToDecimal(FirstValue))));
                                }
                                else if (currentToken.Value == "*")
                                {
                                    EvaluationStack.Push(new Token(TokenTypes.Number, Convert.ToString(Convert.ToDecimal(SecondValue) * Convert.ToDecimal(FirstValue))));
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Unexpected TokenType in EvaluationStack");
                        }
    
                    }
    
                    if (EvaluationStack.Count != 1)
                    {
                        throw new Exception("Unexpected number of Tokens in EvaluationStack");
                    }
                    else
                    {
                        Console.WriteLine("ANSWER: " + EvaluationStack.Peek().Value);
                    }
                    #endregion
                }
                catch (Exception Err)
                {
                    Console.WriteLine("ERROR: " + Err.Message);
                }
    
                Console.ReadLine();
            }
    
            static Stack<Token> GetTokens(string Equation)
            {
                Stack<Token> Tokens = new Stack<Token>();
                string store = "";
    
                while (Equation.Length > 0)
                {
                    string ThisChar = Equation.Substring(0, 1);
    
                    if (Regex.IsMatch(ThisChar, "[0-9\\.]"))
                    {
                        store += ThisChar;
                    }
                    else if (ThisChar == "(" || ThisChar == ")" || ThisChar == "+" || ThisChar == "-" || ThisChar == "/" || ThisChar == "*")
                    {
                        if (store != "")
                        {
                            Tokens.Push(new Token(TokenTypes.Number, store));
                            store = "";
                        }
                        if (ThisChar == "(" || ThisChar == ")")
                        {
                            Tokens.Push(new Token(TokenTypes.Parenthesis, ThisChar));
                        }
                        else if (ThisChar == "+" || ThisChar == "-" || ThisChar == "/" || ThisChar == "*")
                        {
                            Tokens.Push(new Token(TokenTypes.Operator, ThisChar));
                        }
                    }
                    else
                    {
                        // ignore blanks (unless between to numbers)
                        if (ThisChar == " " && !(store != "" && Regex.IsMatch(Equation.Substring(1, 1), "[0-9\\.]")))
                        { }
                        else
                        {
                            throw new Exception("Invalid character in equation: " + ThisChar);
                        }
                    }
                    Equation = Equation.Substring(1);
                }
    
                if (store != "")
                {
                    Tokens.Push(new Token(TokenTypes.Number, store));
                    store = "";
                }
    
                Stack<Token> Return = new Stack<Token>();
                while (Tokens.Count > 0) Return.Push(Tokens.Pop());
    
                return Return;
            }
        }
    }
