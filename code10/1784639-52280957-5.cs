    using System;
    using Microsoft.Deployment.WindowsInstaller;
    
    namespace UninstallMsiViaDTF
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Update this name to search for your product. This sample searches for "Orca"
                var productcode = FindProductCode("orca");
    
                try
                {
                    if (String.IsNullOrEmpty(productcode)) { throw new ArgumentNullException("productcode"); }
    
                    // Note: Setting InstallUIOptions to silent will fail uninstall if uninstall requires elevation since UAC prompt then does not show up 
                    Installer.SetInternalUI(InstallUIOptions.Full); // Set MSI GUI level (run this function elevated for silent mode)
                    Installer.ConfigureProduct(productcode, 0, InstallState.Absent, "REBOOT=\"ReallySuppress\"");
    
                    // Check: Installer.RebootInitiated and Installer.RebootRequired;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
    
                Console.ReadLine(); // Keep console open
            }
    
            // Find product code for product name. First match found wins
            static string FindProductCode(string productname)
            {
                var productcode = String.Empty;
    
                foreach (ProductInstallation product in ProductInstallation.AllProducts)
                {
                    if (product.ProductName.ToLower().Contains(productname.ToLower()))
                    {
                        productcode = product.ProductCode;
                        break;
                    }
                }
    
                return productcode;
            }
        }
    }
