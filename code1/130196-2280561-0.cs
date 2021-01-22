    public delegate void pfnCallback(uint PromptID, ttsEventType evt, IntPtr lData);
    public pfnCallback cb = new pfnCallback(cback);
    public Form1()
    {
        (...)
        Wrapper.SetCallback(handle, cb, IntPtr.Zero, CallBackType.DEFAULT);
        (...)
    }
