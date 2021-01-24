    namespace ConsoleApp4
    {
        class SortOrder
        {
        public Func<DataRec, object> PropName { get; set; }
        public bool Ascending { get; set; }
        }
        public class DataRec
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Order { get; set; }
            public int Year1 { get; set; }
            public int Year2 { get; set; }
        }
        class Program
        {
    
    
            static void Main(string[] args)
            {
               List<DataRec> myData = new List<DataRec>();
            myData.Add(new DataRec() { ID = 1, Name = "A", Order = 1, Year1 = 2011, Year2 = 2009 });
            myData.Add(new DataRec() { ID = 2, Name = "A", Order = 1, Year1 = 2011, Year2 = 2010 });
            myData.Add(new DataRec() { ID = 3, Name = "B", Order = 1, Year1 = 2008, Year2 = 2008 });
            myData.Add(new DataRec() { ID = 4, Name = "B", Order = 1, Year1 = 2009, Year2 = 2009 });
            myData.Add(new DataRec() { ID = 5, Name = "A", Order = 2, Year1 = 2008, Year2 = 2009 });
            myData.Add(new DataRec() { ID = 6, Name = "B", Order = 1, Year1 = 2008, Year2 = 2011 });
            //var orderedData = myData.GroupBy(x=>x.Name, (key, group) =>group.OrderByDescending(x => x.Order).ThenBy(x => x.Year1).ThenByDescending(x => x.Year2).First()).ToList();
            List<SortOrder> sorting = new List<SortOrder>();
            sorting.Add(new SortOrder() { PropName = x => x.Order, Ascending = false });
            sorting.Add(new SortOrder() { PropName = x => x.Year1, Ascending = true });
            sorting.Add(new SortOrder() { PropName = x => x.Year2, Ascending = false });
            var orderedData = myData.GroupBy(x=>x.Name);
            IOrderedEnumerable<DataRec> sorted;
            List<DataRec> result = new List<DataRec>();
            foreach (var oneGroup in orderedData)
            {
                sorted = null;
                foreach (SortOrder oneSort in sorting)
                {
                    if (sorted == null)
                    {
                        sorted = oneSort.Ascending ? oneGroup.OrderBy(oneSort.PropName) : oneGroup.OrderByDescending(oneSort.PropName);                      
                    }
                    else
                    {
                        sorted = oneSort.Ascending ? sorted.ThenBy(oneSort.PropName): sorted.ThenByDescending(oneSort.PropName);
                    }
                }
                result.Add(sorted.First());
            }
        }
