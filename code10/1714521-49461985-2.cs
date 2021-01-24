    Stack cstack = new Stack();
                string input = "PoP";
                foreach (char c in input.ToUpper())
                {
                    cstack.Push(c);
                }
                string popresult = string.Empty;
                bool isPalindrome = true;
                for(int i=0; i<cstack.Count;i++)
                {
                    if (input[i] != Convert.ToChar(cstack.Pop()))
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
