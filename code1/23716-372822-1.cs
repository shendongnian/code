       static void Main()
        {
            List<SimpleObject> list = new List<SimpleObject>();
            list.Add(new SimpleObject(1,"Jon"));
            list.Add(new SimpleObject( 2,  "Mr Skeet" ));
            list.Add(new SimpleObject( 3,"Miss Skeet" ));
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
            public int Id;
            public string Name;
            public SimpleObject(int id, string name)
            {
                this.Id=id;
                this.Name=name;
            }
            public override string ToString()
            {
                return string.Format("{0} : {1}",Id, Name);
            }
        }
