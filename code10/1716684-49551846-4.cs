    private static Node Parse(TextReader reader)
    {            
        var nodes = new Queue<Node>();
        var root = new Node();
        nodes.Enqueue(root);   
        int ch;
        while ((ch = reader.Read()) != -1)
        {
            char token = (char)ch;
            var node = nodes.Dequeue();  // check 1: Not empty
            node.Symbol = token;
            if ("Q".IndexOf(token) >= 0)
            {
                node.Left = new Node();
                nodes.Enqueue(node.Left);
            }
            else if ("+-*".IndexOf(token) >= 0)
            {
                node.Left = new Node();
                nodes.Enqueue(node.Left);
                node.Right = new Node();
                nodes.Enqueue(node.Right);
            }
        }
        // check 2: Queue should be empty
        return root;         
    }
