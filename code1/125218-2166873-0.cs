    Static Class Module1
    {
        public static void Main()
        {
            Common.ITree<myObj> myTree = default(Common.ITree<myObj>);
            myObj a = new myObj("a");
            myObj b = new myObj("b");
            myObj c = new myObj("c");
            myObj d = new myObj("d");
            myTree = Common.NodeTree<myObj>.NewTree;
            myTree.InsertChild(a).InsertChild(b).InsertChild(c).Parent.Parent.InsertNext(a).InsertChild(b).InsertChild(d).Parent.Parent.InsertNext(b).InsertChild(c).Parent.InsertNext(b).InsertChild(d);
            Console.WriteLine(myTree.ToStringRecursive);
            Console.ReadKey();
        }
    }
    Class myObj
    {
        public string text;
        public myObj(string value)
        {
            text = value;
        }
        public override string ToString()
        {
            return text;
        }
    }
