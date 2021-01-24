    using System;
     using System.Collections;
     using System.Collections.Generic;
    					
      public class Program
      {
    	public static void Main()
    	{
    		Run();
    	}
    
        public static void Run()
             {
                 var ls = new List<int>(){
                     1,3,5,7,9,11
                 };
                 var ls2 = new List<int>(){
                     2,4,6,8,10
                 };
                 
                 var lsContainer = new AdditionContainer<List<int>,int>(ls);
                 var ls2Container = new AdditionContainer<List<int>,int>(ls2); 
                 var finalAnsower =   lsContainer +ls2Container;
                 finalAnsower.List.ForEach(f=>Console.WriteLine(f) );
    
    
        }
    	
         
    }
    
    
    public class AdditionContainer<TList,T>
    
         where TList:List<T>
    {
             public TList List;
             public AdditionContainer(TList list )
             {
                   List=list;   
             }
    
             public static AdditionContainer<TList,T> operator +(AdditionContainer<TList,T> a, AdditionContainer<TList,T> b)
             {
                   b.List.ForEach(l =>{
                      if(!a.List.Contains(l))
                      {
                         a.List.Add(l);  
                      }
                   });
                   return a;
             }       
         }
