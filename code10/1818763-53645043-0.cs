            public async Task Test()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>()
                );
            var response = await server.CreateClient().GetAsync(@"/test");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();
        }
