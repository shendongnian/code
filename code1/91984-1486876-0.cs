        private static bool AssignToChildren(ATBusiness.Objects.Client client, int ACClientID)
        {
            client.ACClientID = ACClientID;
            foreach (ATBusiness.Objects.Client child in client.Clients)
            {
                AssignToChildren(child, ACClientID);
            }
        }
