    public class MyColl : List<ChildObject>
    {
        public void Add(string s1, int a1, int a2)
        {
            base.Add(new ChildObject(s1, a1, a2));
        }
    }
    public class ChildObject
    {
        public ChildObject(string s1, int a1, int a2)
        {
            //...
        }
    }
