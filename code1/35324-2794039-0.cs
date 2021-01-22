    [TestClass]
    public class SpecifyUserDefinedSorting
    {
        private Sorter<Movie> sorter;
        private IQueryable<Movie> unsorted;
        [TestInitialize]
        public void Setup()
        {
            unsorted = from m in Movies select m;
            sorter = new Sorter<Movie>();
            sorter.Register("Name", m1 => m1.Name);
            sorter.Register("Year", m2 => m2.Year);
        }
        [TestMethod]
        public void SortByNameThenYear()
        {
            var instructions = new List<SortInstrcution>()
                                   {
                                       new SortInstrcution() {Name = "Name"},
                                       new SortInstrcution() {Name = "Year"}
                                   };
            var sorted = sorter.SortBy(unsorted, instructions);
            var movies = sorted.ToArray();
            Assert.AreEqual(movies[0].Name, "A");
            Assert.AreEqual(movies[0].Year, 2000);
            Assert.AreEqual(movies[1].Year, 2001);
            Assert.AreEqual(movies[2].Name, "B");
        }
        [TestMethod]
        public void SortByNameThenYearDesc()
        {
            var instructions = new List<SortInstrcution>()
                                   {
                                       new SortInstrcution() {Name = "Name", Direction = SortDirection.Descending},
                                       new SortInstrcution() {Name = "Year", Direction = SortDirection.Descending}
                                   };
            var sorted = sorter.SortBy(unsorted, instructions);
            var movies = sorted.ToArray();
            Assert.AreEqual(movies[0].Name, "B");
            Assert.AreEqual(movies[0].Year, 1990);
            Assert.AreEqual(movies[1].Name, "A");
            Assert.AreEqual(movies[1].Year, 2001);
            Assert.AreEqual(movies[2].Name, "A");
            Assert.AreEqual(movies[2].Year, 2000);
        }
        [TestMethod]
        public void SortByNameThenYearDescAlt()
        {
            var instructions = new List<SortInstrcution>()
                                   {
                                       new SortInstrcution() {Name = "Name", Direction = SortDirection.Descending},
                                       new SortInstrcution() {Name = "Year"}
                                   };
            var sorted = sorter.SortBy(unsorted, instructions);
            var movies = sorted.ToArray();
            Assert.AreEqual(movies[0].Name, "B");
            Assert.AreEqual(movies[0].Year, 1990);
            Assert.AreEqual(movies[1].Name, "A");
            Assert.AreEqual(movies[1].Year, 2000);
            Assert.AreEqual(movies[2].Name, "A");
            Assert.AreEqual(movies[2].Year, 2001);
        }
        [TestMethod]
        public void SortByYearThenName()
        {
            var instructions = new List<SortInstrcution>()
                                   {
                                       new SortInstrcution() {Name = "Year"},
                                       new SortInstrcution() {Name = "Name"}
                                   };
            var sorted = sorter.SortBy(unsorted, instructions); 
            var movies = sorted.ToArray();
            Assert.AreEqual(movies[0].Name, "B");
            Assert.AreEqual(movies[1].Year, 2000);
        }
        [TestMethod]
        public void SortByYearOnly()
        {
            var instructions = new List<SortInstrcution>()
                                   {
                                       new SortInstrcution() {Name = "Year"} 
                                   };
            var sorted = sorter.SortBy(unsorted, instructions); 
            var movies = sorted.ToArray();
            Assert.AreEqual(movies[0].Name, "B");
        }
        private static IQueryable<Movie> Movies
        {
            get { return CreateMovies().AsQueryable(); }
        }
        private static IEnumerable<Movie> CreateMovies()
        {
            yield return new Movie { Name = "B", Year = 1990 };
            yield return new Movie { Name = "A", Year = 2001 };
            yield return new Movie { Name = "A", Year = 2000 };
        }
    }
    public static class SorterExtension
    {
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, Sorter<T> sorter, IEnumerable<SortInstrcution> instrcutions)
        {
            return sorter.SortBy(source, instrcutions);
        }
    }
 
    public class Sorter<TSource>
    {
        private readonly FirstPasses _FirstPasses;
        private readonly FirstPasses _FirstDescendingPasses;
        private readonly NextPasses _NextPasses;
        private readonly NextPasses _NextDescendingPasses; 
        
        public Sorter()
        {
            this._FirstPasses = new FirstPasses();
            this._FirstDescendingPasses = new FirstPasses();
            this._NextPasses = new NextPasses();
            this._NextDescendingPasses = new NextPasses();
        }
        public void Register<TKey>(string name, Expression<Func<TSource, TKey>> selector)
        {
            this._FirstPasses.Add(name, s => s.OrderBy(selector));
            this._FirstDescendingPasses.Add(name, s => s.OrderByDescending(selector));
            this._NextPasses.Add(name, s => s.ThenBy(selector));
            this._NextDescendingPasses.Add(name, s => s.ThenByDescending(selector));
        }
        public IOrderedQueryable<TSource> SortBy(IQueryable<TSource> source, IEnumerable<SortInstrcution> instrcutions)
        {
            IOrderedQueryable<TSource> result = null;
            foreach (var instrcution in instrcutions) 
                result = result == null ? this.SortFirst(instrcution, source) : this.SortNext(instrcution, result); 
            return result;
        }
        private IOrderedQueryable<TSource> SortFirst(SortInstrcution instrcution, IQueryable<TSource> source)
        {
            if (instrcution.Direction == SortDirection.Ascending)
                return this._FirstPasses[instrcution.Name].Invoke(source);
            return this._FirstDescendingPasses[instrcution.Name].Invoke(source);
        }
        private IOrderedQueryable<TSource> SortNext(SortInstrcution instrcution, IOrderedQueryable<TSource> source)
        {
            if (instrcution.Direction == SortDirection.Ascending)
                return this._NextPasses[instrcution.Name].Invoke(source);
            return this._NextDescendingPasses[instrcution.Name].Invoke(source);
        }
        private class FirstPasses : Dictionary<string, Func<IQueryable<TSource>, IOrderedQueryable<TSource>>> { }
 
        private class NextPasses : Dictionary<string, Func<IOrderedQueryable<TSource>, IOrderedQueryable<TSource>>> { } 
    }
     
    internal class Movie
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
    public class SortInstrcution
    {
        public string Name { get; set; }
        public SortDirection Direction { get; set; }
    }
    public enum SortDirection   
    {
        //Note I have created this enum because the one that exists in the .net 
        // framework is in the web namespace...
        Ascending,
        Descending
    }
