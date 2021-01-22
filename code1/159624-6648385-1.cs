    If(User.IsInRole("Product Admins"))
    {
       // do something groovy
    }
    else
       throw new SecurityException();
