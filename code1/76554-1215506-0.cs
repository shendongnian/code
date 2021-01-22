    public IQueryable<ClientSearchDTO> GetClientsDTO()
            {
                return (from client in this.Context.Clients
                       join address in this.Context.ClientAddresses on client.ClientID equals address.ClientID
                       join contact in this.Context.ClientContacts on client.ClientID equals contact.ClientID                   
                       where contact.ContactType == "Phone"
                       group client by new { client.ClientID, client.Surname, client.GivenName } into clientGroup
                       select new ClientSearchDTO()
                        {
                            ClientID = clientGroup.Key.ClientID,
                            Surname = clientGroup.Key.Surname,
                            GivenName = clientGroup.Key.GivenName,
                            Address = clientGroup.Max(x => x.ClientAddresses.FirstOrDefault().Address),
                            PhoneNumber = clientGroup.Max(x => x.ClientContacts.FirstOrDefault().Value)
                        });
            }
