    delegate void MyDelegate();
      static void DoSomething_Flexible(Delegate d)
      {   d.DynamicInvoke();      }
      static void DoSomething_Usable(MyDelegate d)
      {   d();      }
      static void Main(string[] args)
      {
         // requires explicit cast else compile error Error "Cannot convert anonymous method to type 'System.Delegate' because it is not a delegate type	
         DoSomething_Flexible((MyDelegate) delegate { Console.WriteLine("Flexible is here!"); });  
         // Parameter Type is a .NET Delegate, no explicit cast needed here. 
         DoSomething_Usable(delegate { Console.WriteLine("Usable is here!"); });
      }
