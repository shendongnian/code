    public static string ProductName
    {
      get
      {
        #if <companyNameA>
          return Properties.Resources.ProductName_CompanyNameA;
        #elif <companyNameB>
          return Properties.Resources.ProductName_CompanyNameB;
        #else
          return Properties.Resources.ProductName;
        #endif
      }
    }
