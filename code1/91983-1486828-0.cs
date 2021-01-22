    private static bool AssignToChildren(ref ATBusiness.Objects.Client client, int ACClientID)
    {
      client.ACClientID = ACClientID;
      for (int i = client.Clients.Count - 1; i >= 0; i--) 
      {
        AssignToChildren(ref client.Clients[i], ACClientID);
      }
    }
