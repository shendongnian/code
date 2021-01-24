    public PrinterResolution PrinterResolution {
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Process, ResourceScope.Process)]
        get {
            if (printerResolution == null) {
                IntSecurity.AllPrintingAndUnmanagedCode.Assert();
 
                IntPtr modeHandle = printerSettings.GetHdevmode();
                IntPtr modePointer = SafeNativeMethods.GlobalLock(new HandleRef(this, modeHandle));
                SafeNativeMethods.DEVMODE mode = (SafeNativeMethods.DEVMODE) UnsafeNativeMethods.PtrToStructure(modePointer, typeof(SafeNativeMethods.DEVMODE));
 
                PrinterResolution result = PrinterResolutionFromMode(mode);
 
                SafeNativeMethods.GlobalUnlock(new HandleRef(this, modeHandle));
                SafeNativeMethods.GlobalFree(new HandleRef(this, modeHandle));
 
                return result;
            }
            else
                return printerResolution;
        }
        set {
            printerResolution = value;
        }
    }
