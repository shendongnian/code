    public abstract class CustomerDetailsGetter {
        public abstract object getcustdetails();
    }
    // ...
    AdapterCompiler compiler = new AdapterCompiler();
    AdapterFactory<CusomterDetailsGetter> factory = compiler.DefineAdapter<CustomerDetailsGetter>(Order.GetType());
    // now, my code assumes you want to construct an object from whole cloth
    // but the code could be changed to invoke the default constructor and set the
    // adapted object.
    CustomerDetailsGetter getter = factory.Construct(null)
    
    object info = getter.getcustdetails();
