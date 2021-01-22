    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using NUnit.Framework;
    using NUnit.Framework.SyntaxHelpers;
    
    
    namespace StackOverflow.StrongTypedLinqSort
    {
        [TestFixture]
        public class SpecifyUserDefinedSorting
        {
            private Sorter<Movie> sorter;
    
            [SetUp]
            public void Setup()
            {
                var unsorted = from m in Movies select m;
                sorter = new Sorter<Movie>(unsorted);
    
                sorter.Define("NAME", m1 => m1.Name);
                sorter.Define("YEAR", m2 => m2.Year);
            }
    
            [Test]
            public void SortByNameThenYear()
            {
                var sorted = sorter.SortBy("NAME", "YEAR");
                var movies = sorted.ToArray();
    
                Assert.That(movies[0].Name, Is.EqualTo("A"));
                Assert.That(movies[0].Year, Is.EqualTo(2000));
                Assert.That(movies[1].Year, Is.EqualTo(2001));
                Assert.That(movies[2].Name, Is.EqualTo("B"));
            }
    
            [Test]
            public void SortByYearThenName()
            {
                var sorted = sorter.SortBy("YEAR", "NAME");
                var movies = sorted.ToArray();
    
                Assert.That(movies[0].Name, Is.EqualTo("B"));
                Assert.That(movies[1].Year, Is.EqualTo(2000));
            }
    
            [Test]
            public void SortByYearOnly()
            {
                var sorted = sorter.SortBy("YEAR");
                var movies = sorted.ToArray();
    
                Assert.That(movies[0].Name, Is.EqualTo("B"));
            }
    
            private static IQueryable<Movie> Movies
            {
                get { return CreateMovies().AsQueryable(); }
            }
    
            private static IEnumerable<Movie> CreateMovies()
            {
                yield return new Movie {Name = "B", Year = 1990};
                yield return new Movie {Name = "A", Year = 2001};
                yield return new Movie {Name = "A", Year = 2000};
            }
        }
    
    
        internal class Sorter<E>
        {
            public Sorter(IQueryable<E> unsorted)
            {
                this.unsorted = unsorted;
            }
    
            public void Define<P>(string name, Expression<Func<E, P>> selector)
            {
                firstPasses.Add(name, s => s.OrderBy(selector));
                nextPasses.Add(name, s => s.ThenBy(selector));
            }
    
            public IOrderedQueryable<E> SortBy(params string[] names)
            {
                IOrderedQueryable<E> result = null;
    
                foreach (var name in names)
                {
                    result = result == null
                                 ? SortFirst(name, unsorted)
                                 : SortNext(name, result);
                }
    
                return result;
            }
    
            private IOrderedQueryable<E> SortFirst(string name, IQueryable<E> source)
            {
                return firstPasses[name].Invoke(source);
            }
    
            private IOrderedQueryable<E> SortNext(string name, IOrderedQueryable<E> source)
            {
                return nextPasses[name].Invoke(source);
            }
    
            private readonly IQueryable<E> unsorted;
            private readonly FirstPasses firstPasses = new FirstPasses();
            private readonly NextPasses nextPasses = new NextPasses();
    
    
            private class FirstPasses : Dictionary<string, Func<IQueryable<E>, IOrderedQueryable<E>>> {}
    
    
            private class NextPasses : Dictionary<string, Func<IOrderedQueryable<E>, IOrderedQueryable<E>>> {}
        }
    
    
        internal class Movie
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }
    }
