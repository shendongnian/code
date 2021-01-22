    Code Block
    using System;
    
    using System.Collections.Generic;
    
     
    
    namespace ConsoleApplication1
    
    {
        class MSDNSample
        {
           static void Main()
           {
              string input = "a b c d";
       
              Stack<string> myStack = new Stack<string>(
                 input.Split(new string[] { " " }, StringSplitOptions.None));
      
              // Remove the top element (will be d!)
              myStack.Pop();
    
              Queue<string> myQueue = new Queue<string>(
    
              input.Split(new string[] { " " }, StringSplitOptions.None));
    
              // Remove the first element (will be a!)
              myQueue.Dequeue();
    
           }
        }
    }
