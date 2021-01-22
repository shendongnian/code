    foreach (Match match in regex.Matches(inputString))
    {
    	...
    
    	switch (tokenMatch.TokenType)
    	{
    		case TemplateTokenType.Expression:
    			{
    				currentNode.Add(new ExpressionNode(tokenMatch));
    			}
    			break;
    
    		case TemplateTokenType.ForEach:
    			{
    				nodeStack.Push(currentNode);
    
    				currentNode = currentNode.Add(new ForEachNode(tokenMatch));
    			}
    			break;
    		....
    	}
    	
    	....
    }
