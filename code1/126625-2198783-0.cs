    IResourcePolicy irp = (IResourcePolicy)dmo;
    irp.AgentVersion = agentVersion;
    irp.ResourcePolicy = rp;
    if (rp != null)
    {
        irp.AgentPolicyVersion.Version = Convert.ToInt64(policyVersion);
        irp.ResourcePolicyEnabled = Convert.ToBoolean(enabled);
    }
