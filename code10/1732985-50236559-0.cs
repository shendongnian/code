    public class A
    {
        public int Id { get; set; }
        public Nullable<bool> IsPublished { get; set; }
    }
    public static IEnumerable<A> Filter(IEnumerable<A> items, Nullable<bool> v)
    {
        return items.Where(x => x.IsPublished == (v ?? x.IsPublished)).ToList();
    }
    var listy = new List<A>();
    listy.Add(new A() { Id=1, IsPublished=null });
    listy.Add(new A() { Id=2, IsPublished=true });
    listy.Add(new A() { Id=3, IsPublished=false });
    listy.Add(new A() { Id=4, IsPublished=null });
    listy.Add(new A() { Id=5, IsPublished=true });
    listy.Add(new A() { Id=6, IsPublished=false });
