    var items = from item in dataset.Descendants("Product")
    			select new
    			{
    				RefCode = item.Element("SiteCode").Value,
    				Codes = string.Join(", ", item.Elements("SiteCode").Select(x => x.Value)),
    				Status = item.Element("Status").Value
    			};
    Array.ForEach(items.ToArray(), Console.WriteLine);
