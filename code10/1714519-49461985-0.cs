    Stack cstack = new Stack();
                string input = "Pop";
    
                foreach (char c in input)
                {
                    cstack.Push(c);
                }
    
                string popresult = string.Empty;
    
                foreach (char c in cstack)
                {
                    popresult += cstack.Pop();
                }
    
                if (input == popresult)
                {
                    Console.WriteLine("Palindrome");
                }
