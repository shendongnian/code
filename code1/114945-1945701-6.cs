    public class Person:IComparable<Person>,IEquatable<Person>
        { 
            public string Name { get; set; }
            public int Age { get; set; }
            public int CompareTo(Person other)
            {
                if (this.Age == other.Age) return 0;
                return this.Age.CompareTo(other.Age);
            }
            public override string ToString()
            {
                return Name + " aged " + Age;
            }
            public bool Equals(Person other)
            {
                if (this.Name.Equals(other.Name) && this.Age.Equals(other.Age)) return true;
                return false;
            }
        }
    Console.WriteLine("adding items...");
            var observable = new ObservableCollection<Person>()
            {
                new Person { Name = "Katy", Age = 51 },
                new Person { Name = "Jack", Age = 12 },
                new Person { Name = "Bob",  Age = 13 },
                new Person { Name = "John", Age = 14 },
                new Person { Name = "Mary", Age = 41 },
                new Person { Name = "Jane", Age = 20 },
                new Person { Name = "Jim",  Age = 39 },
                new Person { Name = "Sue",  Age = 15 },
                new Person { Name = "Kim",  Age = 19 }
            };
            //what do observers see?
            observable.CollectionChanged += (o, e) => {
                
                if (e.OldItems != null)
                {
                    foreach (var item in e.OldItems)
                    {
                        Debug.WriteLine("removed {0} at index {1}", item, e.OldStartingIndex);
                    }
                }
                
                if (e.NewItems != null)
                {
                    foreach (var item in e.NewItems)
                    {
                        Debug.WriteLine("added {0} at index {1}", item, e.NewStartingIndex);
                    }
                }
            };
            
            Console.WriteLine("\nsorting items...");
            observable.Sort();
