     public static List<ArticleApiModel> GetArticles (int id)
        {
             
            try
            {
                var task = Task<List<ArticleApiModel>>.Run(async () =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                       
                        var response = await client.GetAsync(path1 + "/api/articles/",id);
                        if (response != null)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<ApiResult>(jsonString);
                            return result.Result;
                        }
                    }
                    return null;
                });
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
