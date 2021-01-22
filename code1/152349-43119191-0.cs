    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Data;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
    
        class Person
        {
            public string Name
            {
                get;
                set;
            }
    
            public int Age
            {
                get;
                set;
            }
        }
        
        public class Program
        {
            public static void Main()
            {
                Person[] persons1 = new Person[] { new Person() { Name = "Ahmed", Age = 20 }, new Person() { Name = "Ali", Age = 40 } };
                Person[] persons2 = new Person[] { new Person() { Name = "Zaid", Age = 21 }, new Person() { Name = "Hussain", Age = 22 } };
                Person[] persons3 = new Person[] { new Person() { Name = "Linda", Age = 19 }, new Person() { Name = "Souad", Age = 60 } };
    
                Person[][] personArrays = new Person[][] { persons1, persons2, persons3 };
    
                foreach(Person person in MergeOrderedLists<Person, int>(personArrays, person => person.Age))
                {
                    Console.WriteLine("{0} {1}", person.Name, person.Age);
                }
    
                Console.ReadLine();
            }
    
            static IEnumerable<T> MergeOrderedLists<T, TOrder>(IEnumerable<IEnumerable<T>> orderedlists, Func<T, TOrder> orderBy)
            {
                List<IEnumerator<T>> enumeratorsWithData = orderedlists.Select(enumerable => enumerable.GetEnumerator())
                                                                       .Where(enumerator => enumerator.MoveNext()).ToList();
    
                while (enumeratorsWithData.Count > 0)
                {
                    IEnumerator<T> minEnumerator = enumeratorsWithData[0];
                    for (int i = 1; i < enumeratorsWithData.Count; i++)
                        if (((IComparable<TOrder>)orderBy(minEnumerator.Current)).CompareTo(orderBy(enumeratorsWithData[i].Current)) >= 0)
                            minEnumerator = enumeratorsWithData[i];
    
                    yield return minEnumerator.Current;
    
                    if (!minEnumerator.MoveNext())
                        enumeratorsWithData.Remove(minEnumerator);
                }             
            }
        }   
    }
