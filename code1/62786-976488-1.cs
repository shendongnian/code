    public CheckoutContext GetContext(CheckoutCase c)
    {
       FieldInfo field = c.GetType().GetField(c.ToString());
       object[] attribs = field.GetCustomAttributes(typeof(CheckoutContextAttribute),false);
       CheckountContext result = null;
       if(attribs.Length > 0)
       {
          CheckoutContextAttribute attrib = attribs[0] as CheckoutContextAttribute;
          Type type = attrib.CheckoutType;
          result = Activator.CreateInstance(type) as CheckountContext;
       }
       
       return result;
    }
