    private string m_CurUser;
    public string CurrentUser
    {
		get
        {
			if(string.IsNullOrEmpty(m_CurUser))
            {
				var who = System.Security.Principal.WindowsIdentity.GetCurrent();
				if (who == null)
					m_CurUser = System.Environment.UserDomainName + @"\" + System.Environment.UserName;
				else
					m_CurUser = who.Name;
			}
			return m_CurUser;
        }
	}
