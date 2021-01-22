	public static string[] InfixToPostfix( string[] infixArray )
	{
		var stack = new Stack<string>();
		var postfix = new Stack<string>();
		string st;
		for ( int i = 0 ; i < infixArray.Length ; i++ )
		{
			if ( !( "()*/+-".Contains( infixArray[ i ] ) ) )
			{
				postfix.Push(infixArray[i]);
			}
			else
			{
				if ( infixArray[ i ].Equals( "(" ) )
				{
					stack.Push( "(" );
				}
				else if ( infixArray[ i ].Equals( ")" ) )
				{
					st = stack.Pop();
					while ( !( st.Equals( "(" ) ) )
					{
						postfix.Push( st );
						st = stack.Pop();
					}
				}
				else
				{
					while ( stack.Count > 0 )
					{
						st = stack.Pop();
						if ( RegnePrioritet( st ) >= RegnePrioritet( infixArray[ i ] ) )
						{
							postfix.Push(st);
						}
						else
						{
							stack.Push( st );
							break;
						}
					}
					stack.Push( infixArray[ i ] );
				}
			}
		}
		while ( stack.Count > 0 )
		{
			postfix.Push(stack.Pop());
		}
		return postfix.Reverse().ToArray();
	}
