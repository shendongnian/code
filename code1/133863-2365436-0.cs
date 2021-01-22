    public static class Incoming
    {
        private static object locker = new object();
        private static object lastMessage = null;
        public static object GetMessage()
        {
            lock (locker)
            {
                object tempMessage = lastMessage;
                lastMessage = null;
                return tempMessage;
            }
        }
        public static void SetMessage(object messageArg)
        {
            lock (locker)
            {
                lastMessage = messageArg;
            }
        }
        private static Stack<object> messageStack = new Stack<object>();
        public static object GetMessageStack()
        {
            lock (locker)
            {
                object tempMessage = messageStack.Count > 0 ? messageStack.Pop() : null;
                messageStack.Clear();
                return tempMessage;
            }
        }
        public static void SetMessageStack(object messageArg)
        {
            lock (locker)
            {
                messageStack.Push(messageArg);
            }
        }
    }
