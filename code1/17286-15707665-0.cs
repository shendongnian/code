				void Main()
				{
					List<Func<int>> actions = new List<Func<int>>();
					
					int variable = 0;
					
					var closure = new CompilerGeneratedClosure();
					
					Func<int> anonymousMethodAction = null;
					
					while (closure.variable < 5)
					{
						if(anonymousMethodAction == null)
							anonymousMethodAction = new Func<int>(closure.YourAnonymousMethod);
							
						//we're re-adding the same function 
						actions.Add(anonymousMethodAction);
						
						++closure.variable;
					}
					
					foreach (var act in actions)
					{
						Console.WriteLine(act.Invoke());
					}
				}
				
				class CompilerGeneratedClosure
				{
					public int variable;
					
					public int YourAnonymousMethod()
					{
						return this.variable * 2;
					}
				}
