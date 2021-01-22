    class Program
    {
        static void Main(string[] args){
            Func();
        }
        static void Func(){
            StackFrame frame = new StackFrame(1);
            StackTrace trace = new StackTrace(frame);
            var method = frame.GetMethod();
            Console.WriteLine(method.Name);
        }
    }
