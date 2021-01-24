    public enum HRESULT : uint
    {
        S_FALSE = 0x0001,
        S_OK = 0x0000,
        E_INVALIDARG = 0x80070057,
        E_OUTOFMEMORY = 0x8007000E,
        E_INVALID_PRINTER_NAME = 0x80070709
    }
    [DllImport("Prntvpt.dll")]
    public static extern HRESULT PTOpenProvider(
        [MarshalAs(UnmanagedType.LPWStr)]string pszPrinterName, 
        uint dwVersion, 
        [Out] out IntPtr phProvider);
    [DllImport("Prntvpt.dll")]
    public static extern HRESULT PTCloseProvider(
        IntPtr hProvider
    );
    private void button1_Click(object sender, EventArgs e)
    {
        var printerName = @"Fax";
        IntPtr providerHandle;
        HRESULT result = PTOpenProvider(printerName, 1, out providerHandle);
        if(result == HRESULT.S_OK)
        {
            MessageBox.Show("OK. Handled obtained: " + providerHandle);
            PTCloseProvider(providerHandle);
        }
        else
        {
            MessageBox.Show("Error: " + result);
        }
    }
