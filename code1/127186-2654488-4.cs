    ManagementObject synthetic = Utilities.GetResourceAllocationSettingData(scope,
        ResourceType.Disk, ResourceSubType.DiskSynthetic);
    synthetic["Parent"] = <ideControllerPath>; //or SCSI controller path (WMI path)
    synthetic["Address"] = <diskDriveAddress>; //0 or 1 for IDE
    string[] RASDs = new string[1];
    RASDs[0] = synthetic.GetText(TextFormat.CimDtd20);
