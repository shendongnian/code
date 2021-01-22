    using System.Reflection;
    using System.Messaging;
    ...
            Type t = typeof(MessageQueueException);
            ConstructorInfo ci = t.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, 
              null, new Type[] { typeof(int) }, null);
            MessageQueueException ex = (MessageQueueException)ci.Invoke(new object[] { 911 });
            throw ex;
