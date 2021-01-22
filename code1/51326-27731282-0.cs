    public class YearDayBill
    {
    	public string Name;
    	public int YearDay;
    }
    
    public class EatOutDaysOfYear
    {
    	public string Name;
    	public List<int> YearDays;
    }
    
    public static class Program
    {
        static void Main()
        {
            var eatouts = new List<EatOutDaysOfYear>
            {
                new EatOutDaysOfYear {Name = "amit", YearDays = new List<int>() {59, 37, 31, 17, 29}},
                new EatOutDaysOfYear {Name = "prakash", YearDays = new List<int>() {6, 18, 13}},
                new EatOutDaysOfYear {Name = "sarvo", YearDays = new List<int>() {9, 7, 47, 56, 82, 96}},
                new EatOutDaysOfYear {Name = "akshay", YearDays = new List<int>() {8, 5, 2, 4}}
            };
            var bills = eatouts
                .Select(a => a.YearDays
                    .Select(b => new YearDayBill {Name = a.Name, YearDay = b}))
                .SelectMany(c => c)
                .OrderBy(d => d.Name)     // optional 
                .ThenBy(e => e.YearDay)   // optional 
                .ToList();
            bills.ForEach(a => Console.WriteLine(string.Concat(a.Name, " | ", a.YearDay)));
        }
    }
