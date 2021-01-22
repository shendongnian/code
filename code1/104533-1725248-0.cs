    class ProductA_User : ICustomer
    {
        //... implement ICustomer
    }
    class ProductB_User : ICustomer
    {
        //... implement ICustomer
    }
    class ProductC_User : ICustomer
    {
        //... implement ICustomer
    }
    class MemberFactory 
    {
         ICustomer Create(ProductTypeEnum productType)
         {
             switch(productType)
             {
                 case ProductTypeEnum.ProductA: return new ProductA();
                 case ProductTypeEnum.ProductB: return new ProductB();
                 case ProductTypeEnum.ProductC: return new ProductC();
                 default: return null;
             }
         }
    }
