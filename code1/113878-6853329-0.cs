    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace GadgetActivator
    {
        [ComImport]
        [Guid("C1646BC4-F298-4F91-A204-EB2DD1709D1A")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IDesktopGadget
        {
            uint RunGadget([MarshalAs(UnmanagedType.LPWStr)] string gadgetPath);
        }
    }
