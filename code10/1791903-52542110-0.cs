        using (var client = new PowerBIClient(new Uri(ApiUrl), tokenCredentials))
        {
                // Get a list of workspaces.
                var workspaces = await client.Groups.GetGroupsAsync();
        }
