    static void Main(string[] args) {
        var data = new[] {
            new Node{ Id = 1, ParentId = 0, Position = 0, Title = "root" },
            new Node{ Id = 2, ParentId = 1, Position = 0, Title = "child 1" },
            new Node{ Id = 3, ParentId = 1, Position = 1, Title = "child 2" },
            new Node{ Id = 4, ParentId = 1, Position = 2, Title = "child 3" },
            new Node{ Id = 5, ParentId = 3, Position = 0, Title = "grandchild 1" }
        };
        Func<Node, XElement> transform = null;
        transform = node => new XElement(node.Title.Replace(' ','_'),
            from child in data
            where child.ParentId == node.Id
            orderby child.Position
            select transform(child)
        );
        var x = transform(data[0]);
        Console.WriteLine(x.ToString());
    }
