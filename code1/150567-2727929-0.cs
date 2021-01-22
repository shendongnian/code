        using System;
        using System.Runtime.InteropServices;
    
        namespace SimpleLibrary
        {
            [ComVisible(true)]
            [Guid("71F645D0-AA78-4447-BA26-3A2443FDA691")]
            public interface ISixGenerator
            {
                int Six();
            }
        
            [ComVisible(true)]
            [ProgId("SimpleLibrary.SixGenerator")]
            [Guid("8D59E0F6-4AE3-4A6C-A4D9-DFE06EC5A514")]
            [ClassInterface(ClassInterfaceType.AutoDispatch)]
            public class SixGenerator : ISixGenerator
            {
                [DispId(1)]
                public int Six()
                {
                    return 6;
                }
            }
        }        
