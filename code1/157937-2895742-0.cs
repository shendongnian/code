    private static bool IsInstalled(string ProductName)
    {
        bool rv = false;
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
        ManagementObjectCollection Products = searcher.Get();
        if (Products.Count != 0)
        {
            foreach (ManagementObject product in Products)
            {
                if (product.Properties["Name"].Value.ToString() == ProductName)
                {
                    rv = true;
                }
            }
        }
        return rv;           
    }
