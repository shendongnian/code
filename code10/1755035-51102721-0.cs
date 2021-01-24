    class Program
    {
        static void Main(string[] args)
        {
            //First clear the screen.  We need to have absolute knowledge of what's on 
            //the screen for this to work.
            Console.Clear();
            //hide the cursor as it has no real bearing on much....
            Console.CursorVisible = false;
            var user = GetLimitedInput("UserName?", 0, 10, true);
            var password = GetLimitedInput("Password?", 4, 5, false);
            Console.Clear();
            Console.WriteLine($"User is {user} and password is {password}");
        }
        private static string GetLimitedInput(string prompt, 
            int lineToShowPromptOn, int maxChars, bool showChars)
        {
            //set cursor to the suggested position
            Console.SetCursorPosition(0, lineToShowPromptOn);
            //output the prompt.
            Console.WriteLine(prompt);
            Console.SetCursorPosition(0, lineToShowPromptOn + 1);
            var finished = false;
            var inputText = string.Empty;
                        
            while (!finished)
            {
                if (Console.KeyAvailable)
                {
                    //remembr old input so we can re-display if required.
                    var oldInput = inputText;
                    var key = Console.ReadKey();
                    //check for CTRL+C to quit
                    if (key.Modifiers.HasFlag(ConsoleModifiers.Control) && key.KeyChar=='c')
                    {
                        inputText = string.Empty;
                        finished = true;
                    }
                    //allow backspace
                    else if (key.KeyChar == '\b')
                    {
                        if (inputText.Length > 0)
                        {
                            inputText = inputText.Substring(0, inputText.Length - 1);
                        }
                    }
                    //check for return & finish if legal input.
                    else if (key.KeyChar == '\r')
                    {
                        if (inputText.Length<=maxChars)
                        {
                            finished = true;
                        }
                    }
                    else
                    {
                        //really we should check for other modifier keys (CTRL, 
                        //ALT, etc) but this is just example.
                        //Add text onto the input Text
                        inputText += key.KeyChar;
                    }
                    if (inputText.Length > maxChars)
                    {
                        //Display error on line under current input.
                        Console.SetCursorPosition(0, lineToShowPromptOn + 2);
                        Console.WriteLine("Too many characters!");
                    }
                    else
                    {
                        //if not currently in an 'error' state, make sure we
                        //clear any previous error.
                        Console.SetCursorPosition(0, lineToShowPromptOn + 2);
                        Console.WriteLine("                     ");
                    }
                    //if input has changed, then refresh display of input.
                    if (inputText != oldInput)
                    {
                        Console.SetCursorPosition(0, lineToShowPromptOn + 1);
                        //do we show the input?
                        if (showChars)
                        {
                            //We write it out to look like we're typing, and add 
                            //a bunch of spaces as otherwise old input may be        
                            //left there.
                            Console.WriteLine(inputText+"            ");
                        }
                        else
                        {
                            //show asterisks up to length of input.
                            Console.WriteLine(new String('*', inputText.Length)+"            ");
                        }
                    }
                }
            }
            return inputText;
        }       
    }
