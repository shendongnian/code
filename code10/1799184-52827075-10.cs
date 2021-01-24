    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myEnumerable = new MyEnumerable<Person>();
    
                foreach (var person in myEnumerable)
                    Console.WriteLine(person.Name);
    
                Console.ReadKey();
            }
    
            // OUTPUT
            // Test 0
            // Test 1
            // Test 2
        }
    
        public class Person
        {
            static int personCounter = 0;
            public string Name { get; } = "Test " + personCounter++;
        }
    
        public class MyEnumerator<T> : IEnumerator<T>
        {
            private T First { get; set; }
            private T Second { get; set; }
            private T Third { get; set; }
            private int counter = 0;
    
            object IEnumerator.Current => (IEnumerator<T>)Current;
            public T Current { get; private set; }
    
            public bool MoveNext()
            {
                if (counter > 2) return false;
    
                counter++;
                switch (counter)
                {
                    case 1:
                        First = Activator.CreateInstance<T>();
                        Current = First;
                        break;
                    case 2:
                        Second = Activator.CreateInstance<T>();
                        Current = Second;
                        break;
                    case 3:
                        Third = Activator.CreateInstance<T>();
                        Current = Third;
                        break;
                }
                return true;
            }
    
            public void Reset()
            {
                counter = 0;
                First = default;
                Second = default;
                Third = default;
            }
    
            public void Dispose() => Reset();
        }
    
        public class MyEnumerable<T> : IEnumerable<T>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>();
        }
    }
