    public Client[] GetClientList()
    {
        try
        {
            using (var session = SessionHelper.OpenSession())
            {
                return session.Linq<Client>().Where(p => p.ClientID > 0).ToArray<Client>();
            }
        }
        catch (Exception e)
        {
            EventLog.WriteEntry("eCOWS.Data", e.Message);
            return null;
        }
    }
