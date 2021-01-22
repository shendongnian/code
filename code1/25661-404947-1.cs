    internal class Tester
    {
        // Methods
        public void Method1(Stack<string> strings, MsgParser parser, bool parseMsg, bool processMsg)
        {
            string msg;
            while (!string.IsNullOrEmpty(msg = strings.Pop()))
            {
                this.RaiseMessageReceived();
                if (parseMsg)
                {
                    ParsedMsg parsedMsg = parser.ParseMsg(msg);
                    this.RaiseMessageParsed();
                    if (processMsg)
                    {
                        this.process(parsedMsg);
                        this.RaiseMessageProcessed();
                    }
                }
            }
        }
    
        public void Method2(Stack<string> strings, MsgParser parser, bool parseMsg, bool processMsg)
        {
            string msg;
            while (!string.IsNullOrEmpty(msg = strings.Pop()))
            {
                this.RaiseMessageReceived();
                if (parseMsg)
                {
                    ParsedMsg parsedMsg = parser.ParseMsg(msg);
                    this.RaiseMessageParsed();
                    if (processMsg)
                    {
                        this.process(parsedMsg);
                        this.RaiseMessageProcessed();
                    }
                }
            }
        }
    
        private void process(ParsedMsg msg)
        {
            Console.WriteLine(msg);
        }
    
        private void RaiseMessageParsed()
        {
            Console.WriteLine("Message parsed");
        }
    
        private void RaiseMessageProcessed()
        {
            Console.WriteLine("Done");
        }
    
        private void RaiseMessageReceived()
        {
            Console.WriteLine("Message received.");
        }
    }
