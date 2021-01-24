    class Program
    {
        static void Main(string[] args)
        {
            string header = @"{
    ""totalCount"": 12,
    ""pageSize"": 3,
    ""currentPage"": 1,
    ""totalPages"": 4
	}";
            string content = @"[
    {
		""id"": 1,
		""name"": ""Hans""
    },
    {
		""id"": 2,
		""name"": ""Peter""
    },
    {
		""id"": 3,
		""name"": ""Max""
    }
	]";
            var modelList = JsonConvert.DeserializeObject<PagedClientModelList<Person>>(header);
            modelList.Content = JsonConvert.DeserializeObject<List<Person>>(content);
            Console.ReadKey();
        }
    }
