    public bool setPrinterToGrayScale(string printerName) 
    {
      short monochroom = 1;
      dm = this.GetPrinterSettings(printerName);
      dm.dmColor = monochroom;
      Marshal.StructureToPtr(dm, yDevModeData, true);
      pinfo.pDevMode = yDevModeData;
      pinfo.pSecurityDescriptor = IntPtr.Zero;
      
      Marshal.StructureToPtr(pinfo, ptrPrinterInfo, true);
      lastError = Marshal.GetLastWin32Error();
     
      nRet = Convert.ToInt16(SetPrinter(hPrinter, 2, ptrPrinterInfo, 0));
      if (nRet == 0)
      {
        //Unable to set shared printer settings.
        lastError = Marshal.GetLastWin32Error();
        //string myErrMsg = GetErrorMessage(lastError);
        throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
       }
       if (hPrinter != IntPtr.Zero)
          ClosePrinter(hPrinter);
        return Convert.ToBoolean(nRet);
    }
