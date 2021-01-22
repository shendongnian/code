        public class Node
        {
            string name;
            Node parent;
            protected Node(string name,Node parent)
            {
               this.name = name;
               this.parent = parent;
            }
            public static Node Create(string name,Node parent)
            {
               Node result = Activator.CreateInstance(typeof(Node),BindingFlags.Instance  | BindingFlags.NonPublic,null, new object[] { name, parent }, null) as Node;
               return result;
            }
