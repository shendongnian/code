    public void OnInsert(string Argument)
            {
                Console.CursorTop -= 1;
    
    	// moves the cursor to far left so new input overwrites the old.
    
    
    
    	// if arg string is longer, then print arg string then print input 	// string.
    
                if (Argument.Length > input.Length)
                {
                    Console.WriteLine(Argument);
                    Console.WriteLine(input);
                }
                else
                {
    
    	// if the users input if longer than the argument text then print
    	// out the argument text, then print white spaces to overwrite the
    	// remaining input characters still displayed on screen.
    
    
                    for (int i = 0; i < input.Length;i++ )
                    {
                        if (i < Argument.Length)
                        {
                            Console.Write(Argument[i]);
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(input);
                }
            }
	hope this helps some of you, its not perfect, a quick put together test that works enough to be built on.
