        public EventWaitHandle(bool initialState, EventResetMode mode, string name)
        {
            if(name != null)
            {
    #if PLATFORM_UNIX
                throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_NamedSynchronizationPrimitives"));
    #else
                if (System.IO.Path.MaxPath < name.Length)
                {
                    throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong", name));
                }
    #endif
            }
            ...
