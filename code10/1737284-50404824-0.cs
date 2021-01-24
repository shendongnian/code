    class Program
    {
        static void Main(string[] args)
        {
            ComponentClass[] c = new List<ComponentClass>().ToArray();//Data from 3rd party;
            foreach (var data in c)
            {
                Parent p = new Parent();
                if (data.classObjs.Count > 0)
                {
                    Star s = new Star
                    {
                        Area = "infinite",
                        Color = "red"
                    };
                    foreach (var b in data.classObjs)
                    {
                        string bStr = b.GetType() == typeof(ClassA) ? ((ClassA)b).City : ((ClassB)b).Village;
                        bStr = bStr.Split(',').Select(string.Parse).ToList();
                        TinyStar t = new TinyStar
                        {
                            smallD = bStr
                        };
                        s.Values.Add(t);
                    }
                    p.Curves.Add(s);
                }
            }
        }
        public class ComponentClass
        {
            public List<ClassObj> classObjs { get; set; }
        }
        public class ClassObj
        {
            public int ID { get; set; }
            public string Countries { get; set; }
        }
        public class ClassA : ClassObj
        {
            public string City { get; set; }
        }
        public class ClassB : ClassObj
        {
            public string Village { get; set; }
        }
    }
