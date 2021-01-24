    var ObjVirtualMachines = computeClient.VirtualMachines.GetAsync(ressgroup, virtualmname, null, new System.Threading.CancellationToken()).Result;
    var storagemanagementclient = new StorageManagementClient(credentials) { SubscriptionId = credentials.DefaultSubscriptionId };
    ObjVirtualMachines.StorageProfile.DataDisks.Add(new DataDisk(
    ObjVirtualMachines.StorageProfile.DataDisks.Count + 1,
    DiskCreateOptionTypes.Attach,
    name,
    null,
    null,
    null,
    null,
    new ManagedDiskParametersInner(resourceid, acctype)));
    var newUpdateVM = computeClient.VirtualMachines.CreateOrUpdateAsync(ressgroup, virtualmname, ObjVirtualMachines);
