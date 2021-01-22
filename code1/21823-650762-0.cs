    Microsoft.Win32.RegistryKey registrykeyHKLM = Microsoft.Win32.Registry.LocalMachine;
    string cpuPath = @"HARDWARE\DESCRIPTION\System\CentralProcessor";
    Microsoft.Win32.RegistryKey registrykeyCPUs = registrykeyHKLM.OpenSubKey(cpuPath, false);
    StringBuilder sbCPUDetails = new StringBuilder();
    int iCPUCount;
    for (iCPUCount = 0; iCPUCount < registrykeyCPUs.SubKeyCount; iCPUCount++)
    {
        Microsoft.Win32.RegistryKey registrykeyCPUDetail = registrykeyHKLM.OpenSubKey(cpuPath + "\\" + iCPUCount, false);
        string sMHz = registrykeyCPUDetail.GetValue("~MHz").ToString();
        string sProcessorNameString = registrykeyCPUDetail.GetValue("ProcessorNameString").ToString();
        sbCPUDetails.Append(Environment.NewLine + "\t" + string.Format("CPU{0}: {1} MHz for {2}", new object[] { iCPUCount, sMHz, sProcessorNameString }));
        registrykeyCPUDetail.Close();
    }
    registrykeyCPUs.Close();
    registrykeyHKLM.Close();
    sCPUSpeed = iCPUCount++ + " core(s) found:" + sbCPUDetails.ToString();
