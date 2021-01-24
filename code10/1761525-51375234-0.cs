        public void AddClient(Client client)  
        {  
            connection.Insert<Client>(client);
            //after save client.Id.
  
        }
