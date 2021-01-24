    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.PeopleService.v1;
    using Google.Apis.PeopleService.v1.Data;
    public class GoogleContacts
    {
        private String m_client_secret = "......";
        private String m_client_id = ".......apps.googleusercontent.com";
 
        public GoogleContacts()
        {
            // Create OAuth credential.
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = m_client_id,
                    ClientSecret = m_client_secret
                },
                new[] { "profile", "https://www.googleapis.com/auth/contacts.readonly" },
                "me",
                CancellationToken.None).Result;
            // Create the service.
            var service = new PeopleServiceService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "My App",
            });
			// Groups list ////////////
            ContactGroupsResource groupsResource = new ContactGroupsResource(service);
            ContactGroupsResource.ListRequest listRequest = groupsResource.List();
            ListContactGroupsResponse response = listRequest.Execute();
            // eg to show name of each group
            List<string> groupNames = new List<string>();
            foreach (ContactGroup group in response.ContactGroups)
            {
                groupNames.Add(group.FormattedName);
            }
            ///////////////
          
            // Contact list ////////////
            PeopleResource.ConnectionsResource.ListRequest peopleRequest =
                service.People.Connections.List("people/me");
            peopleRequest.PersonFields = "names,emailAddresses";
            peopleRequest.SortOrder = (PeopleResource.ConnectionsResource.ListRequest.SortOrderEnum) 1;
            ListConnectionsResponse people = peopleRequest.Execute();
            // eg to show display name of each contact
            List<string> contacts = new List<string>();
            foreach (var person in people.Connections)
            {
                contacts.Add(person.Names[0].DisplayName);
            }
            ///////////////
        }
    }
