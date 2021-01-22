    using System;
    using System.Collections;
    using System.Collections.Generic; 
    
    class Test{
    
        //Prints the contents of any generic Stack by 
        //using generic type inference 
        public static void PrintStackContents<T>(Stack<T> s){
            while(s.Count != 0){
                Console.WriteLine(s.Pop()); 
            } 
        }
        
        public static void Main(String[] args){
        
        Stack<int> s2 = new Stack<int>(); 
        s2.Push(4); 
        s2.Push(5); 
        s2.Push(6); 
        
        PrintStackContents(s2); 	
        
        Stack<string> s1 = new Stack<string>(); 
        s1.Push("One"); 
        s1.Push("Two"); 
        s1.Push("Three"); 
        
        PrintStackContents(s1); 
        }
    }
