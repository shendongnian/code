    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
        public Tree() { }
        public Tree(IEnumerable<TreeNode<T>> children)
        {
            Root = new TreeNode<T>(children);
        }
    }
    class TreeNode<T>
    {
        private List<TreeNode<T>> children;
        public IList<TreeNode<T>> Children
        {
            get
            {
                if (children == null) children = new List<TreeNode<T>>();
                return children;
            }
        }
        private readonly T value;
        public TreeNode() { }
        public TreeNode(T value) { this.value = value; }
        public TreeNode(T value, IEnumerable<TreeNode<T>> children) : this(children)
        {
            this.value = value;
        }
        public TreeNode(IEnumerable<TreeNode<T>> children)
        {
            children = new List<TreeNode<T>>(children);
        }
    }
    class Element { }
    class Cell : Element {
        public Cell(string x, string y, string z) { }
    }
    class Agent : Element {
        public Agent(string x, string y, string z) { }
    }
    class NodeAgent : Element {
        public NodeAgent(string x, string y, string z) { }
    }
    static class Program
    {
        static void Main()
        {
            XElement ops = XElement.Load(@"c:\temp\exp.xml");
            Tree<Element> domain = new Tree<Element>(
                from cell in ops.Elements("cell")
                select new TreeNode<Element>(
                    new Cell(
                        (string)cell.Attribute("name"),
                        (string)cell.Attribute("name"), null),
                        (
                            from agent in cell.Elements("agent")
                            select new TreeNode<Element>(new Agent(
                                (string)agent.Attribute("name"),
                                (string)agent.Attribute("name"), null),
                                    from na in agent.Elements("node-agent")
                                    select new TreeNode<Element>(
                                        new NodeAgent(
                                            (string)na.Attribute("name"),
                                            (string)na.Attribute("name"), null)
                                    )))));
        }
    }
