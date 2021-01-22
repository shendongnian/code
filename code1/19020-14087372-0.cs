      static void Main()
            {
                IEnumerable<char> query = "aaa bbb ccc";
                string lettersToRemove = "ab";
    
                Console.WriteLine("\nOK with foreach:");
                foreach (var item in lettersToRemove)
                {
                    query = query.Where(c => c != item);   
                }   
                foreach (char c in query) Console.Write(c);
    
                //OK:
                Console.WriteLine("\nOK with foreach and local temp variable:");
                query = "aaa bbb ccc";
    
                foreach (var item in lettersToRemove)
                {
                    var tmp = item;
                    query = query.Where(c => c != tmp);
                }            
                foreach (char c in query) Console.Write(c);
    
    
                /*
                 An IndexOutOfRangeException is thrown because:
                 firstly compiler iterates the for loop treating i as an outsite declared variable  
                 when the query is finnaly invoked the same variable of i is captured (lettersToRemove[i] equals 3) which generates IndexOutOfRangeException
    
                 The following program writes aaa ccc instead of writing ccc:
                 Each iteration gets the same variable="C", i (last one frome abc). 
                 */
    
                //Console.WriteLine("\nNOK with for loop and without temp variable:");
                //query = "aaa bbb ccc";
                
                //for (int i = 0; i <  lettersToRemove.Length; i++)
                //{
                //    query = query.Where(c => c != lettersToRemove[i]);
                //}
                //foreach (char c in query) Console.Write(c);
    
                /*
                 OK
                 The solution is to assign the iteration variable to a local variable scoped inside the loop
                 This causes the closure to capture a different variable on each iteration.
                */
                Console.WriteLine("\nOK with for loop and with temp variable:");
                query = "aaa bbb ccc";
    
                for (int i = 0; i < lettersToRemove.Length; i++)
                {
                    var tmp = lettersToRemove[i];
                    query = query.Where(c => c != tmp);
                }
                foreach (char c in query) Console.Write(c);
            } 
