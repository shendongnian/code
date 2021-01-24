        public string GetAdminToken(string userName, string passWord)
        {
            var request = CreateRequest("/rest/default/V1/integration/admin/token", Method.POST);
            var user = new Credentials();
            user.username = userName;
            user.password = passWord;
            string Json = JsonConvert.SerializeObject(user, Formatting.Indented);
            request.AddParameter("aplication/json", Json, ParameterType.RequestBody);
            var response = Client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content;
            }
            else
            {
                return "";
            }
        }
