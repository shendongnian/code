    string versionDeploy = Application.ProductVersion;				
    if (System.Diagnostics.Debugger.IsAttached)
    {
    	this.lblVersion.Caption = string.Format("Versión {0} DESA", versionDeploy);
    }
    else
    {
    	if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
    	{
    		Version Deploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
    		versionDeploy = string.Format("{0}.{1}.{2}.{3}", Deploy.Major, Deploy.Minor, Deploy.Build, Deploy.Revision);
    	}
    	this.lblVersion.Caption = string.Format("Versión {0} PROD", versionDeploy);
    }
