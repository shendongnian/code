    public static object getKey(string Name)
    {
        RegistryKey uac = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Lsa\FIPSAlgorithmPolicy", true);
        if (uac == null)
        {
            uac = Registry.LocalMachine.CreateSubKey(@"System\CurrentControlSet\Control\Lsa\FIPSAlgorithmPolicy");
        }
        return uac.GetValue(Name);
    }
