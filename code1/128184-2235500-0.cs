    using System;
    using System.Xml.Serialization;
    using System.Diagnostics;
    class Program {
        class TestListener : TraceListener {
            protected override void WriteIndent() {
                if (NeedIndent) {
                    string indent = new string(' ',IndentLevel * IndentSize);
                    Console.Write(indent);
                }
            }
            public override void Write(string message) {
                WriteIndent();
                Console.Write(message);
            }
            public override void WriteLine(string message) {
                WriteIndent();
                Console.WriteLine(message);
            }
        }
        public static void Main(params string[] args) {
            Trace.Listeners.Add(new TestListener());
            Trace.IndentSize = 2;
            Trace.WriteLine("test");
            Trace.IndentLevel = 4;
            Trace.WriteLine("indented");
        }
    }
