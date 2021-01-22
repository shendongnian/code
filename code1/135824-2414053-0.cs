    class Program {
        static void Main(string[] args) {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            new MyClass().MyMethod(44, "asdf qwer 1234", 3.14f, true);
            Console.ReadKey();
        }
    }
    public class MyClass {
        public MyClass() {
        }
        [Trace("Debug")]
        public int MyMethod(int x, string someString, float anotherFloat, bool theBool) {
            return x + 1;
        }
    }
    [Serializable]
    public sealed class TraceAttribute : OnMethodBoundaryAspect {
        private readonly string category;
    
        public TraceAttribute(string category) {
            this.category = category;
        }
        
        public string Category { get { return category; } }
    
        public override void OnEntry(MethodExecutionArgs args) {
            Trace.WriteLine(string.Format("Entering {0}.{1}.", 
                                          args.Method.DeclaringType.Name, 
                                          args.Method.Name), category);
            
            for (int x = 0; x < args.Arguments.Count; x++) {
                Trace.WriteLine(args.Method.GetParameters()[x].Name + " = " + 
                                args.Arguments.GetArgument(x));
            }
        }
    
        public override void OnExit(MethodExecutionArgs args) {
            Trace.WriteLine("Return Value: " + args.ReturnValue);
    
            Trace.WriteLine(string.Format("Leaving {0}.{1}.", 
                                          args.Method.DeclaringType.Name, 
                                          args.Method.Name), category);
        }
    } 
