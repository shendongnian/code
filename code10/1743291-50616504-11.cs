        // Passes the given message to all registered handlers that are capable of handling this message.
        public void HandleMessage(IMessage message)
        {
            List<Handler> handlers = null;
            var messageType = message.GetType();
            if (m_messageHandlers.TryGetValue(messageType, out handlers))
            {
                foreach (var handler in handlers)
                {
                    var target = handler.Component;
                    var methodInfo = handler.Method;
                    // Invoke the method directly and pass in the method object.
                    // Note that this assumes that the target method takes only one parameter of type IMessage.
                    methodInfo.Invoke(target, new object[] { message });
                }
            }
            else
            {
                Console.WriteLine(string.Format("No handler found for message of type {0}", messageType.FullName));
            }
        }
    };
