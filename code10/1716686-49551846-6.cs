    private static Node Parse(TextReader reader)
    {            
        var nodes = new Queue<Node>();
        var root = new Node();
        nodes.Enqueue(root);   
        int ch;
        while ((ch = reader.Read()) != -1)
        {
            char token = (char)ch;
            // syntax check 1: the queue should not be empty
            var node = nodes.Dequeue();  
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
            // else : 0 children
        }
        // syntax check 2: the queue should now be empty
        return root;         
    }
