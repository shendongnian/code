    internal class Program
    {
        private static void Main()
        {
            var ms = new Category(1, "Microsoft");
            var sun = new Category(2, "Sun");
    
            var events = new List<Event>
                             {
                                 new Event(ms, "msdn event"),
                                 new Event(ms, "mix"),
                                 new Event(sun, "java event")
                             };
    
            var microsoftFilter = new Filter<Event>(e => e.CategoryId == ms.CategoryId);
    
            var microsoftEvents = FilterEvents(events, microsoftFilter);
            
            Console.Out.WriteLine(microsoftEvents.Count);
        }
    
        public static List<Event> FilterEvents(List<Event> events, Filter<Event> filter)
        {
            return events.FindAll(e => filter.IsSatisfied(e));
        }
    }
    
    public class Filter<T> where T: class
    {
        private readonly Predicate<T> criteria;
    
        public Filter(Predicate<T> criteria)
        {
            this.criteria = criteria;
        }
    
        public bool IsSatisfied(T obj)
        {
            return criteria(obj);
        }
    }
    
    public class Event
    {
        public Event(Category category, string name)
        {
            CategoryId = category.CategoryId;
            Name = name;
        }
    
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
    
    public class Category
    {
        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
