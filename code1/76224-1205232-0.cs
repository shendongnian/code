    [MessageHandlerAttribute("HandleLoginResponse")]
    private void HandleLoginResponse(object obj, TcpClient client)
    ...
    foreach(MethodInfo method in this.GetType().GetMethods())
    {
        MessageHandlerAttribute attr = Attribute.GetCustomAttribute(method, typeof(MessageHandlerAttribute)) as MessageHandlerAttribute;
        if (attr != null)
        {
            HANDLER_FUNC func = Delegate.CreateDelegate(typeof(HANDLER_FUNC), this, method);
            handlers.Add(attr.HandlerName, func);
        }
    }
