    public void AddVMToInventory(string vmxFilePath, string vmName, string hostName, string resourcePoolName, string folderName)
        {
            try
            {
                // Filter host per host name/IP
                var hostFilter = new NameValueCollection { { "name", hostName } };
                HostSystem host = ((HostSystem)m_client.FindEntityView(typeof(HostSystem), null, hostFilter, null));
                var hostMoRef = ((HostSystem)m_client.FindEntityView(typeof(HostSystem), null, hostFilter, null)).MoRef;
                // Filter resource pool per resource pool name and host
                var poolFilter = new NameValueCollection { { "name", resourcePoolName }, { "parent", host.Parent.Value } };
                var poolMoRef = ((ResourcePool)m_client.FindEntityView(typeof(ResourcePool), null, poolFilter, null)).MoRef;
                // Filter folder per EXACT name
                var folderFilter = new NameValueCollection { { "name", "^" + folderName + "$" } };
                var folder = (Folder)m_client.FindEntityView(typeof(Folder), null, folderFilter, null);
                folder.RegisterVM_Task(vmxFilePath, vmName, false, poolMoRef, hostMoRef);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Adding VM {0} to host {1} failed due to {2}", vmName, hostName, ex));
            }
