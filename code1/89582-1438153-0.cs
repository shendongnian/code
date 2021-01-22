		public static string[] InfixToPostfix( string[] infixArray )
		{
			var stack = new Stack<string>();
			var postfix = new string[ infixArray.Length ];
			int index = 0;
			string st;
			for ( int i = 0 ; i < infixArray.Length ; i++ )
			{
				if ( !( "()*/+-".Contains( infixArray[ i ] ) ) )
				{
					postfix[ index ] = infixArray[ i ];
					index++;
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
							postfix[ index ] = st;
							index++;
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
								postfix[ index ] = st;
								index++;
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
				postfix[ index ] = stack.Pop();
				index++;
			}
			return postfix.TakeWhile( item => item != null ).ToArray();
		}
