    try
    {
        using (var factory4 = new Factory4())
        {
            SwapChain1 swapChain1 = new SwapChain1(factory4, CommandQueue, ref swapChainDescription);
            SwapChain = swapChain1.QueryInterface<SwapChain2>();
        }
     }
     catch (Exception e)
     {
         Debug.WriteLine(e.Message);
         return;
     }
     using (ISwapChainPanelNative nativeObject = ComObject.As<ISwapChainPanelNative>(MainSwapChainPanel))
         nativeObject.SwapChain = SwapChain;
