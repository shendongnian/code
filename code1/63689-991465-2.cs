    namespace Covariant {
    
      class A {
        public virtual string Name() { return "A"; }
      }
    
      class B : A {
        public override string Name() { return "B"; }
      }
    
      delegate List<A> CCastDelegate(List<B> b);  // be used in the cast
    
      class Program {
    
        static unsafe List<A> CastBasAIL(List<B> bIn) {
    
          DynamicMethod dynamicMethod = new DynamicMethod("foo1", typeof(List<A>), new[] { typeof(List<B>) }, typeof(void));
          ILGenerator il = dynamicMethod.GetILGenerator();
          il.Emit(OpCodes.Ldarg_0);                     // copy first argument  to stack
          il.Emit(OpCodes.Ret);                         // return the item on the stack
          CCastDelegate HopeThisWorks = (CCastDelegate)dynamicMethod.CreateDelegate(typeof(CCastDelegate));
    
          return HopeThisWorks(bIn);
    
        }
    
        static void Main(string[] args) {
    
          // make a list<B>
          List<B> b = new List<B>();
          b.Add(new B());
          b.Add(new B());
    
          // set list<A> = the list b using the covariant work around
          List<A> a = CastBasAIL(b);
    
          // at this point the debugger is miffed with a, but code exectuing methods of a work just fine.
          // It may be that the debugger simply checks that type of the generic argument matches the 
          // signature of the type, or it may be that something is really screwed up.  Nothing ever crashes.
    
          // prove the cast really worked
          TestA(a);
    
          return;
    
        }
    
        static void TestA(List<A> a) {
    
          Console.WriteLine("Input type: {0}", typeof(List<A>).ToString());
          Console.WriteLine("Passed in type: {0}\n", a.GetType().ToString());
    
          // Prove that A is B
          Console.WriteLine("Count = {0}", a.Count);
          Console.WriteLine("Item.Name = {0}", a[0].Name());
    
          // see if more complicated methods of List<A> still work
          int i = a.FindIndex(delegate(A item) { return item.Name() == "A"; });
          Console.WriteLine("Index of first A in List<A> = {0}", i);
          i = a.FindIndex(delegate(A item) { return item.Name() == "B"; });
          Console.WriteLine("Index of first B in List<A> = {0}\n", i);
    
          // can we convert a to an array still?
          Console.WriteLine("Iterate through a, after converting a to an array");
          foreach (var x in a.ToArray())
            Console.WriteLine("{0}", x.Name());
    
        }
      }
    }
