    public class MSIInfo
    	{
    		public string ProductCode { get; set; }
    		public string Language { get; set; }
    		public string ProductName { get; set; }
    		public string PackageCode { get; set; }
    		public string Transforms { get; set; }
    		public string AssignmentType { get; set; }
    		public string PackageName { get; set; }
    		public string InstalledProductName { get; set; }
    		public string VersionString { get; set; }
    		public string RegCompany { get; set; }
    		public string RegOwner { get; set; }
    		public string ProductID { get; set; }
    		public string ProductIcon { get; set; }
    		public string InstallLocation { get; set; }
    		public string InstallSource { get; set; }
    		public string InstallDate { get; set; }
    		public string Publisher { get; set; }
    		public string LocalPackage { get; set; }
    		public string HelpLink { get; set; }
    		public string HelpTelephone { get; set; }
    		public string URLInfoAbout { get; set; }
    		public string URLUpdateInfo { get; set; }
    
    		public override string ToString()
    		{
    			return $"{ProductName} - {ProductCode}";
    		}
    
    		public static IEnumerable<MSIInfo> GetProducts()
    		{
    			Type installerType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
    
    			Installer installerObj = (Installer)Activator.CreateInstance(installerType);
    			WindowsInstaller.Installer installer = installerObj as WindowsInstaller.Installer;
    			var Products = installerObj.Products;
    
    			List<MSIInfo> ProductCollection = new List<MSIInfo>();
    
    			foreach (var product in Products)
    			{
    				MSIInfo msi = new MSIInfo();
    				msi.ProductCode = product.ToString();
    
    				foreach (var property in msi.GetType()?.GetProperties())
    				{
    					try
    					{
    						if (property.Name != "ProductCode")
    						{
    							string val = installer.ProductInfo[product.ToString(), property.Name];
    							property.SetValue(msi, val);
    						}
    					}
    					catch (System.Runtime.InteropServices.COMException)
    					{
    					}
    				}
    				ProductCollection.Add(msi);
    			}
    
    			return ProductCollection;
    
    		}
    	}
