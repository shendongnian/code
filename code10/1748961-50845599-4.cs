    [DllImport("C:\\Users\\BME 320 - Section 1\\Documents\\Visual Studio 2015\\Projects\\EyeTrackDll\\x64\\Debug\\EyeTrackDll.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void eyeData(IntPtr); 
    private void button1_Click(object sender, EventArgs e) 
    { 
        try 
        { 
            IntPtr[] ipr = new ItrPtr[4]; // Memory blob to pass to the DLL, Not sure if syntax is correct.
            eyeData(ipr);
            double[] eyeTrackData = new double[4]; // Your C# data
            Marshal.Copy(ipr, eyeTrackData, 0, 4); // Convert?
        }
        finally 
        { 
            Marshal.FreeHGlobal(ipr); 
        }
    } 
