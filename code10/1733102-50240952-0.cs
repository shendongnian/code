    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static Data GetDataFromGroup(IGrouping<int, Data> dataGroup)
    	{
    		Data data = new Data();
    		data.ID = dataGroup.Key;
    		data.Description = dataGroup.Select(d => d.Description).FirstOrDefault(s => !string.IsNullOrWhiteSpace(s))?? string.Empty;
    		data.Description2 = dataGroup.Select(d => d.Description2).FirstOrDefault(s => !string.IsNullOrWhiteSpace(s))?? string.Empty;
    		data.Name = dataGroup.Select(d => d.Name).FirstOrDefault(s => !string.IsNullOrWhiteSpace(s))?? string.Empty;
    		data.Name2 = dataGroup.Select(d => d.Name2).FirstOrDefault(s => !string.IsNullOrWhiteSpace(s))?? string.Empty;
    		return data;
    	}
    	
        public static void Main()
        {
            var dataItems = new List<Data>
            {
                new Data { ID = 555, Name = "newname", Description = "a descript" },
                new Data { ID = 555, Name2 = "name2", Description2 = "Description2name" },
                new Data { ID = 543, Name = "onename", Description = "myname" },
            };
    
            var computedData = dataItems
                .GroupBy(x => x.ID, x => x)
                .Select(g => GetDataFromGroup(g));
    
            foreach (var item in computedData)
            {
                Console.WriteLine($"{item.ID}\t{item.Name}\t{item.Description}\t{item.Name2}\t{item.Description2}");
            }	
    	}
    }
    
    
    public sealed class Data
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
    }
