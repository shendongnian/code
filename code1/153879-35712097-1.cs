    // Define delegate matching api function
    private delegate int GetSystemMetrics(int index);
    
    // Create new WrapperClient
    // Remember to ensure a call to the Dispose()-Method!
    using (var client = new WrapperClient())
    {
        // Make calls providing library name, function name, and parameters
        int x = (int)client.Invoke<GetSystemMetrics>("User32.dll", "GetSystemMetrics", new object[] { 0 });
        int y = (int)client.Invoke<GetSystemMetrics>("User32.dll", "GetSystemMetrics", new object[] { 1 });
    }
