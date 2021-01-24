    enum Operation
    {
        Add,
        Multiply,
        UnaryMinus,
        None,
    }
    static class OperationExtensions
    {
        public static string ToFriendlyString(this Operation me)
        {
            switch (me)
            {
                case Operation.None:
                    return "";
                case Operation.Add:
                    return "+";
                case Operation.Multiply:
                    return "*";
                case Operation.UnaryMinus:
                    return "-";
                default:
                    throw new ArgumentException();
            }
        }
    }
    class OperationNode
    {
        public Operation Op;
        public OperationNode(Operation op)
        {
            Op = op;
        }
    }
    interface IVisitor
    {
        string Visit(OperationNodeLeaf node);
        string Visit(OperationNode1 node);
        string Visit(OperationNode2 node);
    }
    sealed class Visitor : IVisitor
    {
        private string Enclose(OperationNode subNode, Operation op)
        {
            string res = Visit((dynamic)subNode);
            if (subNode.Op < op) // Here we do the check
            {
                res = "(" + res + ")";
            }
            return res;
        }
        public string Visit(OperationNodeLeaf node)
        {
            return node.Op.ToFriendlyString() + node.Value.ToString();
        }
        public string Visit(OperationNode1 node)
        {
            return node.Op.ToFriendlyString() + Enclose(node.SubNode, node.Op);
        }
        public string Visit(OperationNode2 node)
        {
            return Enclose(node.LeftSubNode, node.Op) + node.Op.ToFriendlyString() + Enclose(node.RightSubNode, node.Op);
        }
    }
    class OperationNodeLeaf : OperationNode
    {
        public int Value;
        public OperationNodeLeaf(int v, Operation op = Operation.None) : base(op)
        {
            Value = v;
        }
        void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
    class OperationNode1 : OperationNode
    {
        public OperationNode SubNode;
        public OperationNode1(OperationNode sn, Operation op) : base(op)
        {
            SubNode = sn;
        }
        void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
    class OperationNode2 : OperationNode
    {
        public OperationNode LeftSubNode;
        public OperationNode RightSubNode;
        public OperationNode2(OperationNode lsn, OperationNode rsn, Operation op) : base(op)
        {
            LeftSubNode = lsn;
            RightSubNode = rsn;
        }
        void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tree = 
                new OperationNode2(
                    new OperationNodeLeaf(5),
                    new OperationNode2(
                        new OperationNode2(new OperationNodeLeaf(1), new OperationNodeLeaf(2), Operation.Multiply),
                        new OperationNode1(new OperationNodeLeaf(7, Operation.None), Operation.UnaryMinus),
                        Operation.Add
                        ),
                    Operation.Multiply
                    );
            var visitor = new Visitor();
            var res = visitor.Visit(tree);
            System.Diagnostics.Debug.WriteLine(res);
        }
    }
