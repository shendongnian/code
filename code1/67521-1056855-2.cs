    [STAThread]
    private static void Main()
    {
        MMAppInitialize mmAppInitialize = new MMAppInitialize();
        mmAppInitialize.IsProductCodeAvailable(mmLicensedProductCode.mmLPDesigner);
        mmAppInitialize.Initialize(mmLicensedProductCode.mmLPDesigner);
        mmAppInitialize.Shutdown();
    }
