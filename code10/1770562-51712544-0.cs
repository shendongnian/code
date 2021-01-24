        class Program
        {
            static void Main(string[] args)
            {
                List<A> aS = new List<A>();
                List<B> bS = new List<B>();
                List<C> cS = new List<C>();
                List<D> dS = new List<D>();
                var temp = (from b in bS
                            join c in cS on b.id equals c.id
                            join d in dS on b.id equals d.id
                            select new { b = b, c = c, d = d })
                           .GroupBy(x => x.b.id)
                           .Where(x => (x.Any(y => y.d.Active == 1)) && (x.Count() >= 5))
                           .ToList();
                var results = aS.Where(x => !temp.Any(y => y.First().b.id == x.id)).ToList();
            }
     
        }
        public class A
        {
            public int id { get; set; }
        }
        public class B
        {
            public int id { get; set; }
        }
        public class C
        {
            public int id { get; set; }
        }
        public class D
        {
            public int id { get; set; }
            public int Active { get; set; }
        }
