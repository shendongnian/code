    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestConsoleApp
    {
        class DummyClass
        {
            public string name { get; set; }
            public int value { get; set; }
            public string status { get; set; }
        }
    
        class DummyClassCollection
        {
            private List<DummyClass> _collection;
    
            public DummyClassCollection()
            {
                _collection = new List<DummyClass>();
                FillUpCollection();
            }
    
            public void FillUpCollection()
            {
                _collection.Add(new DummyClass(){
                    name = "A1",
                    value = 1,
                    status = "A"
                });
                _collection.Add(new DummyClass(){
                    name = "A1",
                    value = 2,
                    status = "I"
                });
                _collection.Add(new DummyClass(){
                    name = "A2",
                    value = 3,
                    status = "I"
                });
                _collection.Add(new DummyClass(){
                    name = "A2",
                    value = 4,
                    status = "I"
                });
                _collection.Add(new DummyClass(){
                    name = "A2",
                    value = 5,
                    status = "A"
                });
                _collection.Add(new DummyClass(){
                    name = "A3",
                    value = 6,
                    status = "I"
                });
                _collection.Add(new DummyClass()
                {
                    name = "A3",
                    value = 7,
                    status = "I"
                });
            }
    
            public List<DummyClass> GetCollection()
            {
                return _collection;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var dcc = new DummyClassCollection();
                var collection = dcc.GetCollection();
    
                var result = collection.GroupBy(g => g.name)
                                       .ToDictionary(d => d.Key, d => (d.OrderBy(or => or.status).First()))
                                       .ToDictionary(d => d.Key, d => d.Value);
                Console.ReadKey();
            }
        }
    }
