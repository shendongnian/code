    public ClassA
    {
      private delegate void EventDelegate(int item, int value);
      private EventDelegate _eventCallback;
      private IntPtr _eventCallbackAddress;
      private void OnEvent(int item, int value)
      {
        Debug.WriteLine("Item: " + item + ", value: " + value);
      }
      private void Setup()
      {
        _eventCallback = new EventDelegate(OnEvent);
        _eventCallbackAddress = Marshal.GetFunctionPointerForDelegate(_eventCallback);
        try
        {
          NativeMethods.Configure(_eventCallbackAddress);
        }
        catch (Exception ex)
        {
          Debug.WriteLine(this, ex.Message);
        }
      }
      private static class NativeMethods
      {
        [DllImport("A.dll", EntryPoint = "Configure", CallingConvention = CallingConvention.WinApi)]
        public static extern void Configure(IntPtr eventCallback);
      }
    }        
