    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Tester t=new Tester();
                t.Method1(new Stack<string>(), new MsgParser(), true, true);
                t.Method2(new Stack<string>(), new MsgParser(), true, true);
            }
        }
        class Tester
        {
            public void Method1(Stack<string> strings, MsgParser parser, bool parseMsg, bool processMsg)
            {
                string msg;
                while (!String.IsNullOrEmpty(msg = strings.Pop()))
                {
                    RaiseMessageReceived();
                    if (parseMsg)
                    {
                        ParsedMsg parsedMsg = parser.ParseMsg(msg);
                        RaiseMessageParsed();
                        if (processMsg)
                        {
                            process(parsedMsg);
                            RaiseMessageProcessed();
                        }
                    }
                }
            }
    
            public void Method2(Stack<string> strings, MsgParser parser, bool parseMsg, bool processMsg)
            {
                string msg;
                while (!String.IsNullOrEmpty(msg = strings.Pop()))
                {
                    RaiseMessageReceived();
                    if (!parseMsg) continue;
    
                    ParsedMsg parsedMsg = parser.ParseMsg(msg);
                    RaiseMessageParsed();
                    if (!processMsg) continue;
    
                    process(parsedMsg);
                    RaiseMessageProcessed();
                }
    
            }
    
            private void RaiseMessageProcessed()
            {
                Console.WriteLine("Done");
            }
    
            private void process(ParsedMsg msg)
            {
                Console.WriteLine(msg);
            }
    
            private void RaiseMessageParsed()
            {
                Console.WriteLine("Message parsed");
            }
    
            private void RaiseMessageReceived()
            {
                Console.WriteLine("Message received.");
            }
        }
    
        internal class ParsedMsg
        {
        }
    
        internal class MsgParser
        {
            public ParsedMsg ParseMsg(string msg)
            {
                return new ParsedMsg();
            }
        }
    }
