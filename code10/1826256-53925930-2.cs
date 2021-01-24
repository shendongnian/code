    public static IList<LinkedList<T>> Graph2<T>(LinkedList<T> ll) where T: class
    {
        var resultSet = new List<LinkedList<T>>();
        T prevOperLeft = null;
        T prevOperRight = null;
        while (ll.Count > 0) 
        {
            var left = ll.First.Value;
            ll.RemoveFirst();
            var right = ll.First.Value;
            ll.RemoveFirst();
            if (prevOperRight != null && prevOperRight.Equals(left))
            {
                resultSet.Add(new LinkedList<T>(new []{ prevOperLeft, left, right }));
                prevOperLeft = prevOperRight = null;
            }
            else
            {
                prevOperLeft = left;
                prevOperRight = right;
            }
        }
        return resultSet;
    }
    public static void Main()
    {
        var A = new MyClass {Name = "A"};
        var B = new MyClass {Name = "B"};
        var C = new MyClass {Name = "C"};
        var D = new MyClass {Name = "D"};
        var E = new MyClass {Name = "E"};
        var F = new MyClass {Name = "F"};
        var G = new MyClass {Name = "G"};
        List<MyClass> list = new List<MyClass>
        {
             A,B,B,C,C,D,D,E,C,F,F,G
        };
        LinkedList<MyClass> ll = new LinkedList<MyClass>(list);
        var resultSet2 = Graph2(ll);
    }
    class MyClass
    {
        public string Name { get; set; }
    }
