    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    
    class Program
    {
        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        static extern Int32 MsiGetProductInfo(string product, string property,
            [Out] StringBuilder valueBuf, ref Int32 len);
    
        [DllImport("msi.dll", SetLastError = true)]
        static extern int MsiEnumProducts(int iProductIndex, 
            StringBuilder lpProductBuf);
    
        static void Main(string[] args)
        {
            StringBuilder sbProductCode = new StringBuilder(39);
            int iIdx = 0;
            while (
                0 == MsiEnumProducts(iIdx++, sbProductCode))
            {
                Int32 productNameLen = 512;
                StringBuilder sbProductName = new StringBuilder(productNameLen);
    
                MsiGetProductInfo(sbProductCode.ToString(),
                    "ProductName", sbProductName, ref productNameLen);
    
                if (sbProductName.ToString().Contains("Visual Studio"))
                {
                    Int32 installDirLen = 1024;
                    StringBuilder sbInstallDir = new StringBuilder(installDirLen);
    
                    MsiGetProductInfo(sbProductCode.ToString(),
                        "InstallLocation", sbInstallDir, ref installDirLen);
    
                    Console.WriteLine("ProductName {0}: {1}", 
                        sbProductName, sbInstallDir);
                }
            }
        }
    }
