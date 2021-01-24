    public class MessageBroker
    {
        // Encapsulates a target object and a method to call on that object.
        // This is essentially our own version of a delegate that doesn't require
        // us to explicitly name the type of the arguments the method takes.
        private class Handler
        {
            public IComponent Component;
            public MethodInfo Method;
        };
        private Dictionary<Type, List<Handler>> m_messageHandlers = new Dictionary<Type, List<Handler>>();
        
        public MessageBroker(List<IComponent> components)
        {
            foreach (var component in components)
            {
                var componentType = component.GetType();
                // Get all private and public methods.
                var methods = componentType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                foreach (var method in methods)
                {
                    // If this method doesn't have the Handles attribute then ignore it.
                    var handlesAttributes = (HandlesAttribute[])method.GetCustomAttributes(typeof(HandlesAttribute), false);
                    if (handlesAttributes.Length != 1)
                        continue;
                    // The method must have only one argument.
                    var parameters = method.GetParameters();
                    if (parameters.Length != 1)
                    {
                        Console.WriteLine(string.Format("Method {0} has too many arguments", method.Name));
                        continue;
                    }
                    // That one argument must be derived from IMessage.
                    if (!typeof(IMessage).IsAssignableFrom(parameters[0].ParameterType))
                    {
                        Console.WriteLine(string.Format("Method {0} does not have an IMessage as an argument", method.Name));
                        continue;
                    }
                    // Success, so register!
                    RegisterHandler(handlesAttributes[0].MessageType, component, method);
                }
            }
        }
        // Register methodInfo on component as a handler for messageType messages.
        private void RegisterHandler(Type messageType, IComponent component, MethodInfo methodInfo)
        {
            List<Handler> handlers = null;
            if (!m_messageHandlers.TryGetValue(messageType, out handlers))
            {
                // If there are no handlers attached to this message type, create a new list.
                handlers = new List<Handler>();
                m_messageHandlers[messageType] = handlers;
            }
            var handler = new Handler() { Component = component, Method = methodInfo };
            handlers.Add(handler);
        }
    }
