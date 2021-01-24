    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Mvc;
    // Add/remove as appropriate
    
    namespace YourProject.DAL // Change to your project / repository folder name
    {
        public interface ILicenseInfoRepository : IDisposable
        {
            List<VendorCodeSubscriptionBrandModel> GetSubscriptionBrandsForVendorCode(int keyNumber);
            // Add any other methods that exist in LicenseInfoRepository.cs file
        }
    }
