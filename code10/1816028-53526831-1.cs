	using System;
	using System.Collections.ObjectModel;
	using System.Management.Automation;
	using System.Management.Automation.Runspaces;
	using XenAPI;
	namespace XenSnapshotsXenAccess
	{
		public class XenSessionAccess
		{
			private Session xenSession = null;
			public Session XenSession { get => xenSession; set => xenSession = value; }
			public void Logout()
			{
				if (XenSession != null)
				{
					XenSession.logout(XenSession);
				}
			}
			public XenSessionAccess(string poolMasterServerUrl, string xml_creds_path)
			{
				Collection<PSObject> results = null;
				PSCredential psCredential = null;
				//https://docs.microsoft.com/en-us/powershell/developer/hosting/creating-an-initialsessionstate
				
				//Createdefault2* loads only the commands required to host Windows PowerShell (the commands from the Microsoft.PowerShell.Core module.
				InitialSessionState initialSessionState = InitialSessionState.CreateDefault2();
				using (Runspace runSpace = RunspaceFactory.CreateRunspace(initialSessionState))
				{
					runSpace.Open();
					using (PowerShell powerShell = PowerShell.Create())
					{
						powerShell.Runspace = runSpace;
						powerShell.AddCommand("Import-CliXml");
						powerShell.AddArgument(xml_creds_path);
						results = powerShell.Invoke();
						if (results.Count == 1)
						{
							PSObject psOutput = results[0];
							//cast the result to a PSCredential object
							psCredential = (PSCredential)psOutput.BaseObject;
						}
						else
						{
							throw new System.Exception("Could not obtain pool master server credentials");
						}
					}
					runSpace.Close();
				}
				initialSessionState = InitialSessionState.CreateDefault2();
				initialSessionState.ImportPSModule(new string[] { "XenServerPSModule" });
				initialSessionState.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Unrestricted;
				SessionStateVariableEntry psCredential_var = new SessionStateVariableEntry("psCredential", psCredential, "Credentials to log into pool master server");
				initialSessionState.Variables.Add(psCredential_var);
				SessionStateVariableEntry poolUrl_var = new SessionStateVariableEntry("poolUrl", poolMasterServerUrl, "Url of pool master server");
				initialSessionState.Variables.Add(poolUrl_var);
				using (Runspace runSpace = RunspaceFactory.CreateRunspace(initialSessionState))
				{
					runSpace.Open();
					using (PowerShell powerShell = PowerShell.Create())
					{
						powerShell.Runspace = runSpace;
						powerShell.AddScript(@"$psCredential | Connect-XenServer -url $poolUrl -SetDefaultSession -PassThru");
						results = powerShell.Invoke();
					}
					if (results.Count == 1)
					{
						PSObject psOutput = results[0];
						//cast the result to a XenAPI.Session object
						XenSession = (Session)psOutput.BaseObject;
					}
					else
					{
						throw new System.Exception(String.Format("Could not create session for {0}", poolMasterServerUrl));
					}
					runSpace.Close();
				}
			}
		}
	}
  
