    try
    {
        // do file IO here
    }
    catch (IOException e)
    {
        int HResult = System.Runtime.InteropServices.Marshal.GetHRForException(e)
        if (HResult == 32) // 32 = Sharing violation
        {
            // Recovery logic goes here
        }
        else
        {
            throw; // Or do whatever else here
        }
    }
