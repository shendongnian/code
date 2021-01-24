    using System;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.Text;
    using IronPython.Hosting;
    namespace PythonComObject
    {
        [Guid("F34B2821-14FB-1345-356D-DD1456789BBF")]
        public interface PythonComInterface
        {
            [DispId(1)]
            bool RunSomePython();
            [DispId(2)]
            bool RunPythonScript();
        }
        // Events interface 
        [Guid("414d59b28-c6b6-4e65-b213-b3e6982e698f"), 
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface PythonComEvents 
        {
        }
        [Guid("25a337e0-161c-437d-a441-8af096add44f"),
        ClassInterface(ClassInterfaceType.None),
        ComSourceInterfaces(typeof(PythonComEvents))]
        public class PythonCom : PythonComInterface
        {
            private ScriptEngine _engine;
            public PythonCom()
            {
                // Initialize IronPython engine
                _engine = Python.CreateEngine();
            }
            public bool RunSomePython()
            {
                string someScript = @"def return_message(some_parameter):
                                      return True
                                  return_message()";
                ScriptSource source = _engine.CreateScriptSourceFromString(someScript, SourceCodeKind.Statements);
                
                ScriptScope scope = _engine.CreateScope();
                source.Execute(scope);
                Func<int, bool> ReturnMessage = scope.GetVariable<Func<int, bool>>("return_Message");
                return ReturnMessage(0);
            }
 
            public bool RunPythonScript()
            {
                ScriptSource source =            _engine.CreateScriptSourceFromFile("SomeScript.py");
                ScriptScope scope = _engine.CreateScope();
                source.Execute(scope);               
                Func<int, bool> some_method = scope.GetVariable<Func<int, bool>>("some_method");
                return some_method(1);
            }
        }
    }
