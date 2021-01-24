    using System;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var text = "Hey There";
                var employer1 = new Employer() { Name = "Microsoft" };
                var employer2 = new Employer() { Name = "EA Games" };
    
                //Generic Swap
                SwapGeneric(ref employer1, ref employer2);
                //Swap(ref text, ref employee2); //<- compiler error. Cannot be inferred by the usage.
    
                Console.WriteLine("Types of the same swapped");
                Console.WriteLine(employer1.Name);
                Console.WriteLine(employer2.Name);
                Console.WriteLine();
                //object Swap
                //SwapObject(ref employee1, ref employee2); //- compiler error.  Cannot convert to ref object.
    
                //Reference string and employer as object.
                var textObject = text as object;
                var employerObject = employer1 as object;
    
                SwapObject(ref textObject, ref employerObject);
    
                //Existing types cannot be re-referenced.
                //text = (Employer)textObject; //<-compiler error.  Cannot implicitly convert...
                //employer1 = (string)employerObject; //<-compiler error. Cannot implicitly convert....
    
                //We can cast objects to swapped types succesfully but see how easily this can cause error and confusion.
                Console.WriteLine("Objects of different types swapped");
                Console.WriteLine(((Employer)textObject).Name);
                Console.WriteLine((string)employerObject);
    
                Console.ReadKey();
            }
    
            static void SwapGeneric<T>(ref T var1, ref T var2)
            {
                T temp = var1;
                var1 = var2;
                var2 = temp;
            }
    
            static void SwapObject(ref object var1, ref object var2)
            {
                object temp = var1;
                var1 = var2;
                var2 = temp;
            }
        }
    
        public class Employer
        {
            public object Name { get; set; }
        }
    }
    //OUTPUT
    //Types Swapped
    //EA Games
    //Microsoft
    
    //Objects Swapped
    //EA Games
    //Hey There
