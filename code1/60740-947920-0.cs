    public class FlatObj
    {
        public int Id;
        public int ParentId;
        public int Position;
        public string Title;
    }
    public class Node
    {
        public int ID;
        public string Title;
        public IList<Node> Children;
        public Node(FlatObject baseObject, IList<Node> children)
        {
            this.ID = baseObject.Id;
            this.Title = baseObject.Title;
            this.Children = children;
        }
    }
    public static Node CreateHierarchy(IEnumerable<FlatObject> objects)
    {
        var families = objects.ToLookup(x => x.ParentId);
        var topmost = families[0].Single();
        Func<int, IList<Node>> Children = null;
        Children = (parentID) => families[parentID]
            .OrderBy(x => x.Position)
            .Select(x => new Node(x, Children(x.Id))).ToList();
        return new Node(topmost, Children(topmost.Id));
    }
    public static void Test()
    {
        List<FlatObj> objects = new List<FlatObj> {
        new FlatObj { Id = 1, ParentId = 0, Position = 0, Title = "root" },
        new FlatObj { Id = 2, ParentId = 1, Position = 0, Title = "child 1" },
        new FlatObj { Id = 3, ParentId = 1, Position = 1, Title = "child 2" },
        new FlatObj { Id = 4, ParentId = 1, Position = 2, Title = "child 3" },
        new FlatObj { Id = 5, ParentId = 2, Position = 0, Title = "grandchild" }};
        var nodes = CreateHierarchy(objects);
    }
