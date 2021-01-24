    Stack<char> cstack = new Stack<char>();
                string input = "PoP";
    
                var inputToUpper = input.ToUpper(); /*assuming case senstivity is not to be considered */
    
                foreach (char c in inputToUpper)
                {
                    cstack.Push(c);
                }
               
                bool isPalindrome = true;
                var noOfItems = cstack.Count;
    
                for(int i=0; i< noOfItems ; i++)
                {
                    if (inputToUpper[i] != cstack.Pop())
                    {
                        isPalindrome = false; break;
                    }
                }
    
                if (isPalindrome)
                {
                    Console.WriteLine("Palindrome");
                }
                else
                {
                    Console.WriteLine("Non Palindrome");
                }
