    public class CategoryItem
            {
                public int CategoryID { get; set; }
                public string Category { get; set; }
            }
    
            public class CategoriesRoot
            {
                public IList<CategoryItem> Categories { get; set; }
            }
    		
    		 var tmp = new CategoriesRoot
                    {
                        Categories = new List<CategoryItem> {
                        new CategoryItem { CategoryID = 1, Category = "Pizza" }
                    }
                    };
                    
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(url);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", api);
                        HttpResponseMessage response = client.PostAsJsonAsync("api/categories", tmp).Result;
    					}
