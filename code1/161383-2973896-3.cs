    using System;
    using System.Collections.Generic;
    class MyException : Exception {
        string _excludeFromStackTrace;
        public MyException(string excludeFromStackTrace) {
            _excludeFromStackTrace = excludeFromStackTrace;
        }
        public override string StackTrace {
            get {
                List<string> stackTrace = new List<string>();
                stackTrace.AddRange(base.StackTrace.Split(new string[] {Environment.NewLine},StringSplitOptions.None));
                stackTrace.RemoveAll(x => x.Contains(_excludeFromStackTrace));
                return string.Join(Environment.NewLine, stackTrace.ToArray());
            }
        }
    }
    class Program {
        static void TestExc() {
            throw new MyException("Program.TestExc");
        }
        static void foo() {
            TestExc();
        }
        static void Main(params string[] args) {
            try{
                foo();
            } catch (Exception exc){
                Console.WriteLine(exc.StackTrace);
            }
        }
    }
