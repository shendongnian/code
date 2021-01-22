    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace LinqRecursion
    {
        class Program
        {
            static void Main(string[] args)
            {
                Person mom = new Person() { Name = "Karen" };
                Person me = new Person(mom) { Name = "Matt" };
                Person youngerBrother = new Person(mom) { Name = "Robbie" };
                Person olderBrother = new Person(mom) { Name = "Kevin" };
                Person nephew1 = new Person(olderBrother) { Name = "Seth" };
                Person nephew2 = new Person(olderBrother) { Name = "Bradon" };
                Person olderSister = new Person(mom) { Name = "Michelle" };
    
                Console.WriteLine("\tAll");
                //        All
                //Karen 0
                //Matt 1
                //Robbie 2
                //Kevin 3
                //Seth 4
                //Bradon 5
                //Michelle 6
                foreach (var item in mom)
                    Console.WriteLine(item);
    
                Console.WriteLine("\r\n\tOdds");
                //        Odds
                //Matt 1
                //Kevin 3
                //Bradon 5
                var odds = mom.Where(p => p.ID % 2 == 1);
                foreach (var item in odds)
                    Console.WriteLine(item);
    
                Console.WriteLine("\r\n\tEvens");
                //        Evens
                //Karen 0
                //Robbie 2
                //Seth 4
                //Michelle 6
                var evens = mom.Where(p => p.ID % 2 == 0);
                foreach (var item in evens)
                    Console.WriteLine(item);
    
                Console.ReadLine();
    
            }
        }
    
        public class Person : IEnumerable<Person>
        {
            private static int _idRoot;
    
            public Person() {
                _id = _idRoot++;
            }
            
            public Person(Person parent) : this()
            {
                Parent = parent;
                parent.Children.Add(this);
            }
    
            private int _id;
            public int ID { get { return _id; } }
            public string Name { get; set; }
    
            public Person Parent { get; private set; }
    
            private List<Person> _children;
            public List<Person> Children
            {
                get
                {
                    if (_children == null)
                        _children = new List<Person>();
                    return _children;
                }
            }
    
            public override string ToString()
            {
                return Name + " " + _id.ToString();
            }
    
            #region IEnumerable<Person> Members
    
            public IEnumerator<Person> GetEnumerator()
            {
                yield return this;
                foreach (var child in this.Children)
                    foreach (var item in child)
                        yield return item;
            }
    
            #endregion
    
            #region IEnumerable Members
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
    
            #endregion
        }
    }
