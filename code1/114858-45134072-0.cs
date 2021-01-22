    enter code here
    using System;
    using System.Rwflection;
    using System.IO;
    using Carlibraries;
    namespace LateBinding
    {
    public class program
    {
       static void Main(syring[] args)
       {
             Assembly a=null;
             try
             {
                  a=Assembly.Load("Carlibraries");
             }
             catch(FileNotFoundException e)
             {
                   Console.Writeline(e.Message);
                   Console.ReadLine();
                   return;
             }
             Type miniVan=a.GetType("Carlibraries.MiniVan");
             MiniVan mi=new MiniVan();
             mi.TellChildToBeQuiet("sonu",4);
             Console.ReadLine();
           }
       }
       }
