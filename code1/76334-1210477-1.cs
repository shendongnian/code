    public static int hReceiveTestMessage(IntPtr pInstance, IntPtr pData)
    {
       // provide object context for static member function
       helloworld2 hw = (helloworld2)GCHandle.FromIntPtr(pInstance).Target;
       if (hw == null || pData == null)
       {
          Console.WriteLine("hReceiveTestMessage received NULL data or instance pointer\n");
          return 0;
       }
    
       // populate message with received data
       IntPtr ip2 = GCHandle.ToIntPtr(GCHandle.Alloc(new DataPacketWrap(pData)));
       DataPacketWrap dpw = (DataPacketWrap)GCHandle.FromIntPtr(ip2).Target;
       uint retval = hw.m_testData.load_dataSets(ref dpw);
       // display message contents
       hw.displayTestData();
    
       return 1;
    }
