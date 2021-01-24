    using System;
    using System.Collections.Generic;
    public class Program
    {
     public static void Main()
     {
      List<string> stringList = new List<string>{"one","two","three","four","five","six"};
      stringList.ForEach(x=>{
       Console.WriteLine(x.Replace(x[0],Char.ToUpper(x[0])));
      });
     }
    }   
