        static void Main()
        {
            List<SimpleObject> list = new List<SimpleObject>();
            list.Add(new SimpleObject() { Id=1,Name="Jon" });//This is 3.0 but you can use normal constructor
            list.Add(new SimpleObject() { Id = 2, Name = "Mr Skeet" });//This is 3.0 but you can use normal constructor
            list.Add(new SimpleObject() { Id = 3, Name = "Miss Skeet" });//This is 3.0 but you can use normal constructor
            Predicate<SimpleObject> yourFilterCriteria = delegate(SimpleObject simpleObject)
            {
                return simpleObject.Name.Contains("Skeet");
            };
            list = list.FindAll(yourFilterCriteria);//Get only name that has Skeet : Here is the magic
            foreach (SimpleObject o in list)
            {
                Console.WriteLine(o);
            }
            Console.Read();
        }
        public class SimpleObject
        {
            public int Id { get; set; }//This is 3.0 but you can change to parameter to constructor
            public string Name { get; set; }//This is 3.0 but you can change to parameter to constructor
            public override string ToString()
            {
                return string.Format("{0} : {1}",Id, Name);
            }
        }
