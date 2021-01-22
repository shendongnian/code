    public static Test Create()
    {
        int? a = ReadConfigurationForA();
        string b = ReadConfigurationForB();
        return new Test(a, b);
    }
