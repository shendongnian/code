    using System;
    
    class Test
    {   
        static void Main()
        {
            bool likesCheese = false;
            
            Action outerConditional = likesCheese 
                ? (Action) (() => Console.WriteLine("Outer: I like cheese"))
                : (Action) (() => Console.WriteLine("Outer: I hate cheese"));
            
            Action innerConditional = () => 
                Console.WriteLine (likesCheese ? "Inner: I like cheese" 
                                               : "Inner: I hate cheese");
        
            
            Console.WriteLine("Before change...");
            outerConditional();
            innerConditional();
    
            likesCheese = true;
            Console.WriteLine("After change...");
            outerConditional();
            innerConditional();
        }
    }
