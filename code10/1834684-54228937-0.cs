       Type installerType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            Installer installerObj = (Installer)Activator.CreateInstance(installerType);
            WindowsInstaller.Installer installer = installerObj as WindowsInstaller.Installer;
            var Products = installerObj.Products;
            List<Hashtable> ProductCollection = new List<Hashtable>();
            foreach (var product in Products)
            {
                Hashtable hash = new Hashtable();
                hash.Add("ProductCode", product);
                string[] Attributes = { "Language", "ProductName", "PackageCode", "Transforms", "AssignmentType", "PackageName", "InstalledProductName", "VersionString", "RegCompany", "RegOwner", "ProductID", "ProductIcon", "InstallLocation", "InstallSource", "InstallDate", "Publisher", "LocalPackage", "HelpLink", "HelpTelephone", "URLInfoAbout", "URLUpdateInfo" };
                foreach (var attribute in Attributes)
                {
                    try
                    {
                        var details = installer.ProductInfo[product.ToString(), attribute.ToString()];
                        hash.Add(attribute, details);
                    }
                    catch
                    {
                    }
                }
                ProductCollection.Add(hash);
            }
