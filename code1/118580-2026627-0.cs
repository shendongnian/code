    ResourcePolicy rp = null;
    try
    {
        int rpindex = allObjects.Find(new Guid(policyGuid));
        if (rpindex != -1)
        {
            rp = (ResourcePolicy)allObjects.GetAt(rpindex);
        }
    }
    catch (System.Exception err)
    {
        SpoDebug.DebugTraceSevere(func, "Bad GUID: " + policyGuid + "  Exception: " + err.Message);
    }
    
    if (rp == null)  // this the if loop we need to concentrate
    {
        SpoDebug.DebugTraceSevere(func, "Unable to find ResourcePolicy with GUID: " + policyGuid);
    }
    
    // Search for the specified host
    foreach (DataModelObject dmo in allObjects)
    {
        if (dmo is IResourcePolicy && string.Compare(dmo.Name, hostName, true) == 0))
        {
            IResourcePolicy irp = (IResourcePolicy)dmo;
            irp.AgentVersion = agentVersion;
     
            if (rp != null)
            {
                irp.ResourcePolicy = rp;
                irp.AgentPolicyVersion.Version = Convert.ToInt64(policyVersion);
                irp.ResourcePolicyEnabled = Convert.ToBoolean(enabled);
            }
            
            // ...
        }
    }
