    using System.Reflection;
    ...
    Assembly mhAssembly = Assembly.LoadFrom(mhAssemblyPath);
    Dictionary<MessageType, IMessageHandler> mhMap = new Dictionary<MessageType, IMessageHandler>();
    foreach (Type t in mhAssembly.GetExportedTypes())
    {
       if (t.GetInterface("IMessageHandler") != null)
       {
          MessageHandlerAttribute list = (MessageHandlerAttribute[])t.GetCustomAttributes(
             typeof(MessageHandlerAttribute), false);
          foreach (MessageHandlerAttribute att in list)
          {
             MessageType mt = att.MessageType;
             Debug.Assert(!mhMap.ContainsKey(mt));
             IMessageHandler mh = mhAssembly.CreateInstance(
                t.FullName,
                true,
                BindingFlags.CreateInstance,
                null,
                new object[] { },
                null,
                null);
             mhMap.Add(mt, mh);
          }
       }
       // depending on your application, you might want to check mhMap now to make
       // sure that every MessageType value is in it.
    }
    return mhMap;
