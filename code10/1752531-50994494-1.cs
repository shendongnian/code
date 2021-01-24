    async Task DeleteNonExistantRedirect()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("Http://localhost:43240/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await client.DeleteAsync("api/foos/1"))
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var respOjb = JsonConvert.DeserializeObject<ApiResponeMoedl>(responseContent);
                //respOjb.exceptionMessage
            }
        }
    }
