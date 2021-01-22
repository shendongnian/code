    using System;
    using System.Diagnostics;
    using System.Diagnostics.Tracing;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    namespace MyExample
    {
        // This class traces function entry/exit
        // Constructor is used to automatically log function entry.
        // Dispose is used to automatically log function exit.
        // use "using(FnTraceWrap x = new FnTraceWrap()){ function code }" pattern for function entry/exit tracing
        public class FnTraceWrap : IDisposable
        {
            string methodName;
            string className;
    
            private bool _disposed = false;
    
            public FnTraceWrap()
            {
                StackFrame frame;
                MethodBase method;
    
                frame = new StackFrame(1);
                method = frame.GetMethod();
                this.methodName = method.Name;
                this.className = method.DeclaringType.Name;
    
                MyEventSourceClass.Log.TraceEnter(this.className, this.methodName);
            }
    
            public void TraceMessage(string format, params object[] args)
            {
                string message = String.Format(format, args);
                MyEventSourceClass.Log.TraceMessage(message);
            }
    
            public void Dispose()
            {
                if (!this._disposed)
                {
                    this._disposed = true;
                    MyEventSourceClass.Log.TraceExit(this.className, this.methodName);
                }
            }
        }
    
        [EventSource(Name = "MyEventSource")]
        sealed class MyEventSourceClass : EventSource
        {
            // Global singleton instance
            public static MyEventSourceClass Log = new MyEventSourceClass();
    
            private MyEventSourceClass()
            {
            }
    
            [Event(1, Opcode = EventOpcode.Info, Level = EventLevel.Informational)]
            public void TraceMessage(string message)
            {
                WriteEvent(1, message);
            }
    
            [Event(2, Message = "{0}({1}) - {2}: {3}", Opcode = EventOpcode.Info, Level = EventLevel.Informational)]
            public void TraceCodeLine([CallerFilePath] string filePath = "",
                                      [CallerLineNumber] int line = 0,
                                      [CallerMemberName] string memberName = "", string message = "")
            {
                WriteEvent(2, filePath, line, memberName, message);
            }
    
            // Function-level entry and exit tracing
            [Event(3, Message = "Entering {0}.{1}", Opcode = EventOpcode.Start, Level = EventLevel.Informational)]
            public void TraceEnter(string className, string methodName)
            {
                WriteEvent(3, className, methodName);
            }
    
            [Event(4, Message = "Exiting {0}.{1}", Opcode = EventOpcode.Stop, Level = EventLevel.Informational)]
            public void TraceExit(string className, string methodName)
            {
                WriteEvent(4, className, methodName);
            }
        }
    }
