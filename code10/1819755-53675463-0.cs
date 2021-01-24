    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Xunit;
    namespace Test
    {
		public class TestClass
		{
			public class Company
			{
				public int Id { get; set; }
				public List<int> Companies { get; set; }
			}
			public class Rowdata
			{
				public Rowdata(int companyId, int industryId)
				{
					this.CompanyId = companyId;
					this.IndustryId = industryId;
				}
				public int CompanyId { get; set; }
				public int IndustryId { get; set; }
			}
			[Fact]
			public void Test()
			{
				var data = new List<Rowdata>
				{
					new Rowdata(1, 1),
					new Rowdata(1, 2),
					new Rowdata(2, 1),
					new Rowdata(2, 2),
					new Rowdata(3, 3),
					new Rowdata(3, 4),
					new Rowdata(3, 5)
				};
				var result = data.GroupBy(x => x.CompanyId)
					.Select(x => new Company()
					{
						Id = x.Key,
						Companies = x.Select(y => y.IndustryId).ToList()
					}).ToList();
				foreach (var item in result)
				{
					var text = $"CompanyId : {item.Id}, industries : {string.Join(',',item.Companies)}";
					Debug.WriteLine(text);
				}
			}
		}
	}
