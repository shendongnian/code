        class Wrapper<T>
        {
            public T Value { get; set; }
        }
        
        static void Main(string[] args)
        {
            Node root = new Node
            {
                Name = "First",
                Next = new Node {Name = "Second"}
            };
            
            var method = Build();
            method(root);
        }
        class Node
        {
            public string Name { get; set; }
            public Node Next { get; set; }
        }
        
        static Action<Node> Build()
        {
            var wrapper = new Wrapper<Action<Node>>();
            var param = Expression.Parameter(typeof(Node), "node");
            var expr = Expression.Lambda<Action<Node>>(
                Expression.Block(
                    // Console.WriteLine("Node name: {0}", node.Name);
                    Expression.Call(
                        typeof(Console), 
                        "WriteLine", 
                        Type.EmptyTypes, 
                        Expression.Constant("Node name: {0}"), 
                        Expression.Property(param, "Name")
                    ),
                    // if (node.Next != null) wrapper.Value(node.Next)
                    Expression.IfThen(
                        Expression.ReferenceNotEqual(Expression.Property(param, "Next"), Expression.Constant(null)),
                        // wrapper.Value(node.Next)
                        Expression.Invoke(
                            // wrapper.Value
                            Expression.Property(Expression.Constant(wrapper), "Value"),
                            // node.Next
                            Expression.Property(param, "Next")
                        )
                    )
                ),
                param
            );
            
            return wrapper.Value = expr.Compile();
        }
