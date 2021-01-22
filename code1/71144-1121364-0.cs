    using System;
    using System.Reflection.Emit;
    
    public class App
    {
        static void Main()
        {
            DynamicMethod m = new DynamicMethod("test", typeof(void),
                new[] { typeof(App), // <-- type of first argument, your choice
                    typeof(string) });
            
            var cg = m.GetILGenerator();
            
            cg.Emit(OpCodes.Ldarg_0);
            cg.Emit(OpCodes.Ldarg_1);
            cg.EmitCall(OpCodes.Call,
                typeof(App).GetMethod("ShowString"), null);
            
            cg.Emit(OpCodes.Ret);
            
            Action<string> d = (Action<string>) 
                m.CreateDelegate(typeof(Action<string>), 
                new App()); // <-- this is the first argument, *your* choice
            
            MyEvent += d;
            
            // Trigger event
            MyEvent("Hello there");
        }
        
        static event Action<string> MyEvent;
        
        public void ShowString(string s)
        {
            Console.WriteLine(s);
        }
    }
   
