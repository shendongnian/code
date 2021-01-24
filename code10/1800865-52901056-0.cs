    public static class Utilities
    {
        public static bool DatesOverlap(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd)
        {
            return aStart < bEnd && bStart < aEnd;
        }
        public static IList<MasterEntity> GroupFunky(IList<ItemEntity> list)
        {
            var result = new List<MasterEntity>();
            var ordered = list.OrderBy(x => x.ItemDate).ToArray();
            var startDates = list.Select(x => x.ItemDate);
            var endDates = list.Select(x => x.ItemDate.AddDays(x.Duration));
            var allDates = startDates.Concat(endDates).OrderBy(x => x).ToArray();
            for (var index = 0; index < allDates.Length - 1; index++)
            {
                var group = ordered.Where(x => DatesOverlap(allDates[index], allDates[index + 1], x.ItemDate,
                                                            x.ItemDate.AddDays(x.Duration)));
                var item = new ItemEntity
                {
                    Duration = (allDates[index + 1] - allDates[index]).Days,
                    ItemDate = allDates[index],
                    Field1 = group.First().Field1,
                    Field2 = group.First().Field2,
                    Field3 = group.First().Field3,
                    Field4 = group.First().Field4,
                    GroupName = group.First().GroupName,
                    ItemId = -1,
                    GroupId = -1
                };
                item.ItemDate = allDates[index];
                item.Duration = (allDates[index + 1] - allDates[index]).Days;
                result.Add(new MasterEntity
                {
                    Item = item,
                    GroupList = group.Select(x => x.GroupId).ToList(),
                    ItemList = group.Select(x => x.ItemId).ToList()
                });
            }
            return result.Where(x => x.Item.Duration > 0).ToList();
        }
    }
    public class ItemEntity
    {
        public int ItemId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime ItemDate { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public int Duration { get; set; }
    }
    public class MasterEntity
    {
        public ItemEntity Item { get; set; }
        public List<int> ItemList { get; set; }
        public List<int> GroupList { get; set; }
    }
    public class TestClass
    {
        public static void Main()
        {
            var items = new List<ItemEntity>
            {
                new ItemEntity
                {
                    ItemId = 100,
                    GroupId = 1,
                    GroupName = "Group 1",
                    ItemDate = new DateTime(2018, 10, 15),
                    Duration = 5,
                    Field1 = "Item Name 1",
                    Field2 = "aaa",
                    Field3 = "bbb",
                    Field4 = "abc"
                },
                new ItemEntity
                {
                    ItemId = 150,
                    GroupId = 2,
                    GroupName = "Group 2",
                    ItemDate = new DateTime(2018, 10, 17),
                    Duration = 2,
                    Field1 = "Item Name 1",
                    Field2 = "aaa",
                    Field3 = "bbb",
                    Field4 = "efg"
                },
                new ItemEntity
                {
                    ItemId = 250,
                    GroupId = 3,
                    GroupName = "Group 3",
                    ItemDate = new DateTime(2018, 10, 17),
                    Duration = 5,
                    Field1 = "Item Name 1",
                    Field2 = "aaa",
                    Field3 = "bbb",
                    Field4 = "xyz"
                }
            };
            var group = items.GroupBy(g => new
            {
                g.Field1,
                g.Field2,
                g.Field3
            })
                .Select(x => x.AsQueryable().ToList())
                .ToList();
            var result = group.Select(x => Utilities.GroupFunky(x));
            foreach (var item in result)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
            }
        }
    }
