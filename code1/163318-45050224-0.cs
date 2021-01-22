    {
      ClientContext m_clientContext = new ClientContext(strSiteUrl);
        m_clientContext.ExecutingWebRequest += new EventHandler<WebRequestEventArgs>(ctx_MixedAuthRequest);
        m_clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
        m_clientContext.Credentials = new NetworkCredential(uname, pwd);
        Web m_currentWeb = m_clientContext.Web;
        m_clientContext.Load(m_currentWeb);
        m_clientContext.ExecuteQuery();
    }
      private void ctx_MixedAuthRequest(object sender, WebRequestEventArgs e)
        {
            try
            {
                //Add the header that tells SharePoint to use Windows authentication.
                e.WebRequestExecutor.RequestHeaders.Add(
                "X-FORMS_BASED_AUTH_ACCEPTED", "f");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting authentication header: " + ex.Message);
            }
        }
