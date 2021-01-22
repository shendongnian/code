    interface ICadSystemFactory
    {
        ICadSystem GetSystemInstance();
    }
    class 3dCadSystemVersion1 : ICadSystemFactory
    {
        ICadSystem GetSystemInstance()
        {
            return new 3dCadSystemWrapperVersion1(new 3dCadSystemVersion1());
        }
    }
    class 3dCadSystemVersion2 : ICadSystemFactory
    {
        ICadSystem GetSystemInstance()
        {
            return new 3dCadSystemWrapperVersion2(new 3dCadSystemVersion2());
        }
    }
