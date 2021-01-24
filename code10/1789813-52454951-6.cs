    // The basetype of an item (which contains de RefName etc)
    public class BaseType
    {
        public string RefName { get; set; }
        public string Tag { get; set; }
    }
---
    // static T service with some testdata (mock)
    public static class Data<T> where T : BaseType
    {
        public static List<T> MyData { get; } = new List<T>();
        static Data()
        {
            // create an item
            var item = Activator.CreateInstance<T>();
            item.RefName = "Test";
            item.Tag = "Bla";
            MyData.Add(item);
            var item2 = Activator.CreateInstance<T>();
            item2.RefName = "SomethingElse";
            item2.Tag = "TagThing";
            MyData.Add(item2);
            var item3 = Activator.CreateInstance<T>();
            item3.RefName = "Test2";
            item3.Tag = "Bla2";
            MyData.Add(item3);
        }
    }
