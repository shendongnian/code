     public class StudentServiceTest 
        {
            private readonly TestServer _server;
            private readonly HttpClient _client;
            public StudentServiceTest()
            {
                var config = new ConfigurationBuilder().SetBasePath(Path.GetFullPath(@"..\..\..\..\Student.IntegrationTest"))
                                                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                       .AddEnvironmentVariables();
                var builtConfig = config.Build();
                config.AddAzureKeyVault(
                        $"https://{builtConfig["Vault"]}.vault.azure.net/",
                        builtConfig["ClientId"],
                        builtConfig["ClientSecret"]);
                var Configuration = config.Build();
          
                _server = new TestServer(WebHost.CreateDefaultBuilder()
                    .UseConfiguration(Configuration)
                    .UseStartup<Startup>());
                _client = _server.CreateClient();
                _client.BaseAddress = new Uri("http://localhost:xxxxx");
            }
    
            [Fact]
            public async Task StudentShould()
            {
                try
                {
                    //Act
                    var response = await _client.GetAsync("/api/getStudentByID/200");
                    response.EnsureSuccessStatusCode();
    
                    var responseString = await response.Content.ReadAsStringAsync();
                    
                    //Assert
                    Assert.Equal("bla bla", responseString);
                }
                catch (Exception e)
                {
                    throw;
                }
                
            }
    }
