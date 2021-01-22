        public Get_Client_Repository()
            : this(new CISOnlineSRVDEV.ServiceSoapClient())
        {
             
        }
        public Get_Client_Repository(CISOnlineSRVDEV.ServiceSoapClient serviceSoapClient)
        {
            _ServiceSoapClient = serviceSoapClient;
        }
        public IEnumerable<IClient> GetClient(IClient client)
        {
            // ****  Calling teh web service with passing in the clientId and returning a dataset
            DataSet dataSet = _ServiceSoapClient.get_clients(client.RbhaId,
                                                            client.ClientId,
                                                            client.AhcccsId,
                                                            client.LastName,
                                                            client.FirstName,
                                                            "");//client.BirthDate.ToString());  //TODO: NEED TO FIX
            // USE LINQ to go through the dataset to make it easily available for the Model to display on the View page
            List<IClient> clients = (from c in dataSet.Tables[0].AsEnumerable()
                                     select new Client()
                                     {
                                         RbhaId = c[5].ToString(),
                                         ClientId = c[2].ToString(),
                                         AhcccsId = c[6].ToString(),
                                         LastName = c[0].ToString(), // Add another field called   Sex M/F  c[4]
                                         FirstName = c[1].ToString(),
                                         BirthDate = c[3].ToDateTime()  //extension helper  ToDateTime()
                                     }).ToList<IClient>();
            return clients;
        }
