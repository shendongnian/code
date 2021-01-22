    using System;
    using System.Diagnostics;
    class MyException : Exception
    {
        public MyException(bool hideThrowingMethodFromStackFrame)
        {
            this.hideThrowingMethodFromStackFrame = hideThrowingMethodFromStackFrame;
        }
        readonly bool hideThrowingMethodFromStackFrame;
        public override string StackTrace
        {
            get
            {
                int numberOfFramesToSkip = hideThrowingMethodFromStackFrame ? 2 : 1;
                //    ^ always skip one frame for this current getter method;
                //      optionally skip another for the throwing method.
                return new StackTrace(skipFrames: numberOfFramesToSkip).ToString();
            }
        }
    }
