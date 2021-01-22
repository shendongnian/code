        class MyExceptionClass : Exception
        {
             public MyExceptionClass(string message, string extraInfo) : 
             base(ModifyMessage(message, extraInfo))
             {
             }
             private static string ModifyMessage(string message, string extraInfo)
             {
                 Trace.WriteLine("message was " + message);
                 return message.ToLowerInvariant() + Environment.NewLine + extraInfo;
             }
        }
