            GraphServiceClient client = AuthHelper.GetAuthClient();
            
            var currentUser = await client.Me.Request().GetAsync();
            string id = currentUser.Id;
            
            var test = await client.Me.Extensions.Request().GetAsync();
            Console.WriteLine(currentUser.DisplayName);
            Console.WriteLine("Click to update extension");
            Console.ReadLine();
            Dictionary<string, object> addData = new Dictionary<string, object>()
            {
                {"Key", "Value"}
            };
            var extObject = new OpenTypeExtension()
            {
                ExtensionName = "testExtension",
                AdditionalData = addData
            };
            try
            {
                await client.Me.Extensions.Request().AddAsync(extObject);
            }
            catch (Exception ex)
            {
                //
            }
