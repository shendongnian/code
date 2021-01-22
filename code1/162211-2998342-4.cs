    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    
    class Program
    {
        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        static extern Int32 MsiGetProductInfo(string product, string property, 
            [Out] StringBuilder valueBuf, ref Int32 len);
    
        [DllImport("msi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Int32 MsiEnumRelatedProducts(string strUpgradeCode, 
            int reserved, int iIndex, StringBuilder sbProductCode);
    
        static void Main(string[] args)
        {
            List<string> installedVersions = 
                GetInstalledVersions("{169C1A82-2A82-490B-8A9A-7AB7E4C7DEFE}");
    
            foreach (var item in installedVersions)
            {
                Console.WriteLine(item);
            }
        }
    
        static List<string> GetInstalledVersions(string upgradeCode)
        {
            List<string> result = new List<string>();
            StringBuilder sbProductCode = new StringBuilder(39);
            int iIdx = 0;
            while (
                0 == MsiEnumRelatedProducts(upgradeCode, 0, iIdx++, sbProductCode))
            {
                Int32 len = 512;
                StringBuilder sbVersion = new StringBuilder(len);
                MsiGetProductInfo(sbProductCode.ToString(), 
                    "VersionString", sbVersion, ref len);
                result.Add(sbVersion.ToString());
            }
            return result;
        }
    }
