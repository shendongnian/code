    using System.Collections.Generic;
    using System.Linq;
    
    namespace ListOfListSelectionSpike
    {
        public class ListSpikeClass
        {
            public List<List<MyClass>> ListOfClassLists { get; set; }
    
            private List<MyClass> list1, list2, list3;
    
            public ListSpikeClass()
            {
                var myClassWithId123 = new MyClass("123");
                var myClassWithIs345 = new MyClass("456");
                list1 = new List<MyClass> { myClassWithId123, myClassWithIs345 };
                list2 = new List<MyClass> { myClassWithId123, myClassWithIs345, myClassWithId123 };
                list3 = new List<MyClass> { myClassWithIs345, myClassWithIs345 };
                ListOfClassLists = new List<List<MyClass>> { list1, list2, list3 };
            }
    
            public List<List<MyClass>> GetListOfListsById(string id)
            {
                var result = (from list in ListOfClassLists
                              let listWithTheId =
                                  ((from myClass in list
                                    where myClass.ID == id
                                    select myClass)
                                    .ToList())
                              where listWithTheId.Count > 0
                              select listWithTheId)
                              .ToList();
                return result;
            }
        }
    
        public class MyClass
        {
            public MyClass(string id)
            {
                ID = id;
                Name = "My ID=" + id;
            }
            public string ID { get; set; }
            public string Name { get; set; }
        }
    }
