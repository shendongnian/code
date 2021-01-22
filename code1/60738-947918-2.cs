    class Node {
        public int Id { get;set;  }
        public int ParentId { get;set;  }
        public int Position { get;set;  }
        public string Title { get;set;  }
        public IEnumerable<Node> Children { get; set; }
        public override string ToString() { return ToString(0); }
        public string ToString(int depth) {
            return "\n" + new string(' ', depth * 2) + Title + (
                Children.Count() == 0 ? "" :
                string.Join("", Children
                    .Select(node => node.ToString(depth + 1))
                    .ToArray()
                );
        }
    }
    class Program {
        static void Main(string[] args) {
            var data = new[] {
                new Node{ Id = 1, ParentId = 0, Position = 0, Title = "root" },
                new Node{ Id = 2, ParentId = 1, Position = 0, Title = "child 1" },
                new Node{ Id = 3, ParentId = 1, Position = 1, Title = "child 2" },
                new Node{ Id = 4, ParentId = 1, Position = 2, Title = "child 3" },
                new Node{ Id = 5, ParentId = 3, Position = 0, Title = "grandchild 1" }
            };
            Func<Node, Node> transform = null;
            transform = node => new Node {
                Title = node.Title,
                Id = node.Id,
                ParentId = node.ParentId,
                Position = node.Position,
                Children = (
                    from child in data
                    where child.ParentId == node.Id
                    orderby child.Position
                    select transform(child))
            };
            Console.WriteLine(transform(data[0]));
        }
    }
