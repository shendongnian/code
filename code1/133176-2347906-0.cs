    protected override IKernel CreateKernel()
    {
        IKernel kernel = new StandardKernel(new Log4netModule());            
        kernel.Bind<IDataAccess>().To<DataAccessEntBlock>().InSingletonScope();
        return kernel;
    }
