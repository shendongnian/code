    public class TestClass
    {
        public class CompanyModel
        {
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public List<IndustryModel> Industires { get; set; }
        }
        public class IndustryModel
        {
            public int IndustryId { get; set; }
            public string IndustryName { get; set; }
        }
        public class CompanyFlatDbRowsModel
        {
            public CompanyFlatDbRowsModel()
            {
            }
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public int IndustryId { get; set; }
            public string Industry { get; set; }
        }
        [Fact]
        public void Test()
        {
            var data = new List<CompanyFlatDbRowsModel>
            {
                new CompanyFlatDbRowsModel
                {
                    CompanyId = 1,
                    CompanyName = "Company 1",
                    IndustryId = 1,
                    Industry = "Industry 1"
                },
                new CompanyFlatDbRowsModel
                {
                    CompanyId = 1,
                    CompanyName = "Company 1",
                    IndustryId = 2,
                    Industry = "Industry 2"
                },
                new CompanyFlatDbRowsModel
                {
                    CompanyId = 2,
                    CompanyName = "Company 2",
                    IndustryId = 3,
                    Industry = "Industry 3"
                },
                new CompanyFlatDbRowsModel
                {
                    CompanyId = 2,
                    CompanyName = "Company 2",
                    IndustryId = 4,
                    Industry = "Industry 4"
                },
            };
            var result = data.GroupBy(x => x.CompanyId)
                .Select(x => new CompanyModel()
                {
                    CompanyId = x.Key,
                    CompanyName = x.First().CompanyName,
                    Industires = x.Select(y=> new IndustryModel
                    {
                        IndustryName = y.Industry,
                        IndustryId = y.IndustryId
                    }).ToList()
                }).ToList();
            foreach (var item in result)
            {
                var text = $"Company id : {item.CompanyId}, industries : {string.Join(',',item.Industires.Select(x=>$"(name: {x.IndustryName}, id: {x.IndustryId})"))}";
                Debug.WriteLine(text);
            }
        }
    }
