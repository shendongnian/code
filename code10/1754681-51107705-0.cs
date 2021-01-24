            //Connect to TFS server.
            var tfs = new TfsConfigurationServer(new Uri("tfs server"), new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential("username", "password", "domain"))));
            tfs.EnsureAuthenticated();
            //Get the default collection id.
            var collectionId = new Guid(tfs.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None).First().Resource.Properties["InstanceId"]);
            //Get the default collection.
            var collection = tfs.GetTeamProjectCollection(collectionId);
            //Download files.
            var server = collection.GetClient<TfvcHttpClient>();
            var zip = Path.GetTempFileName();
            var stream = File.Create(zip);
            var item = server.GetItemZipAsync(application.branch_directory + "/" + environment.name).Result;
            item.CopyTo(stream);
            stream.Close();
            try
            {
                ZipFile.ExtractToDirectory(zip, applicationDirectory);
            }
            catch
            {
                throw new Exception("Unable to unzip the file: " + zip);
            }
