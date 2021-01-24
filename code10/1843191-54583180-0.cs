    public static bool IsFullyEncased(string expression)
        {
            if (expression.Length > 1 && expression[0] == '(' && expression[expression.Length-1] == ')')
            {
                // Candidate for a fully enclosed expression: ( .* )
                int openBracketCount = 1;
                for (int i = 1; i < expression.Length - 1; ++i)
                {
                    switch (expression[i])
                    {
                        case '(':
                            openBracketCount += 1;
                            break;
                        case ')':
                            openBracketCount -= 1;
                            break;
                    }
                    // Additionally checks for valid expression (in terms of brackets)
                    if (openBracketCount <= 0) return false;
                    
                }
                // The last element is a bracket so we must have only 1 open
                if(openBracketCount == 1) return true; 
                
            }
            return false;
        }
