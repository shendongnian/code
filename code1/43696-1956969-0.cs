    DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
    public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int size);
    
    StringBuilder dp = new StringBuilder(256);
    int size = dp.Capacity;
    if (GetDefaultPrinter(dp, ref size)) {
            Console.WriteLine(String.Format("Printer: {0}, name length {1}", dp.ToString().Trim(), size));
    } else {
        int rc = GetLastError();
        Console.WriteLine(String.Format("Failed. Size: {0}, error: {1:X}", size, rc));
    }
    
