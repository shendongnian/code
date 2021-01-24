    public async void SomeMethod()
        {
            using (var client = new HttpClient())
            {
                for (int i = 0; i < 10; i++)
                {
                    await client.GetStringAsync("https://www.google.com.ph");
                }
            }            
        }
