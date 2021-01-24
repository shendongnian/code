    var list1 = new List<Object1>();
    var list2 = new List<Object2>();
    var newOrderedByDateCollection = list1
        .Select(i => new TempClass(i, i.updateDate))
        .Concat(list2
            .Select(j => new TempClass(j, j.updateDate)))
        .OrderBy(tmp => tmp.Date)
        .Select(tmp => tmp.OrigItem);
    //This could be replaced by a tuple like Tuple<object, DateTime> but I thought this would come across clearer
    public class TempClass
    {
        public TempClass(object origItem, DateTime date)
        {
            OrigItem = origItem;
            Date = date;
        }
        public object OrigItem { get; set; }
        public DateTime Date { get; set; }
    }
