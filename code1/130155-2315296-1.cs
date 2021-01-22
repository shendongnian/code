    using System.Diagnostics;
    using System.Reflection;
    public class Test {
        public virtual MethodBase GetCallingMethod() {
          StackTrace stackTrace = new StackTrace();
          StackFrame stackFrame;
          MethodBase stackFrameMethod;
          Type stackType;
          int frameCount = 0;
          do {
            frameCount++;
            stackFrame = stackTrace.GetFrame( frameCount );
            stackFrameMethod = stackFrame.GetMethod();
            stackType = stackFrameMethod.ReflectedType;
          } while ( stackType.IsSubclassOf( typeof( Test )) || stackType == typeof( Test ) );
          return stackFrameMethod;
        }
    }
