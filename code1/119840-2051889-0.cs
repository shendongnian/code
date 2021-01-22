    var irp = allObjects.OfType<IResourcePolicy>()
        .FirstOrDefault(item => String.Equals(item.Name, hostName));
    if (irp != null)
    {
         irp.ResourcePolicy = rp;
         irp.AgentPolicyVersion.Version = Convert.ToInt64(policyVersion);
         irp.ResourcePolicyEnabled = Convert.ToBoolean(enabled);
         irp.AgentVersion = agentVersion;
         // I don't know the signature of ServerSendObject, 
         // you might need a cast here:
         SpoServer.Spurt.ServerSendObject(irp, true, 0);
    }
