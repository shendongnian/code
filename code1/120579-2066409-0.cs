public string AgentVersion 
 {
	get
 	{ 
		if(string.isNullOrEmpty(m_version))
		{
			string keySpoPath = SpoRegistry.SpoAgentRoot;
			RegistryKey regkey = Registry.LocalMachine.OpenSubKey(keySpoPath);
			m_version = (string)regkey.GetValue(SpoRegistry.regValue_CurrentVersion);
		}
	         m_version = string.isNullOrEmpty(m_version) ? m_version : "0.0.0.0";
                 return m_version;
        } 
	 
}
string m_version;
  
