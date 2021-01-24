    public class Node {
        public string Header { get; set; }
        public IEnumerable<Node> Items { get; set; }
        public Node() {
            /* Note that I like to start the collections within the object's construction, 
             * to avoid issues inside operations that manipulate these collections. */
            Items = new Collection<Node>();
        }
    }
