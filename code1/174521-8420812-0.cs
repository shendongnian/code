    ConnectionOptions oConn = new ConnectionOptions();
    ManagementScope oScope = null;
    oConn.Username = txtLogin;
    oConn.Password = txtPassword;
    oConn.Authority = "ntlmdomain:" + txtDomain;
    oScope = new ManagementScope("\\\\" + txtHostName + "\\root\\CIMV2", oConn);
    oScope.Connect();
