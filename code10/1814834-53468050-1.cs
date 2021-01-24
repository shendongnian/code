    enum Operation
    {
        Add,
        Multiply,
        Power,
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
                case Operation.Power:
                    return "^";
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
        void Visit(OperationNodeLeaf node);
        void Visit(OperationNode1 node);
        void Visit(OperationNode2 node);
    }
    sealed class Visitor : IVisitor
    {
        public string Text { get; set; }
        private void Enclose(OperationNode subNode, Operation op)
        {
            if (subNode.Op < op)
            {
                Text = Text + "(";
                Visit((dynamic)subNode);
                Text = Text + ")";
            }
            else
            {
                Visit((dynamic)subNode);
            }
        }
        public void Visit(OperationNodeLeaf node)
        {
            Text = Text + node.Op.ToFriendlyString();
            Text = Text + node.Value.ToString();
        }
        public void Visit(OperationNode1 node)
        {
            Text = Text + node.Op.ToFriendlyString();
            Enclose(node.SubNode, node.Op);
        }
        public void Visit(OperationNode2 node)
        {
            Enclose(node.LeftSubNode, node.Op);
            Text = Text + node.Op.ToFriendlyString();
            Enclose(node.RightSubNode, node.Op);
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
                    new OperationNode2(
                        new OperationNode2(new OperationNodeLeaf(5), new OperationNodeLeaf(6), Operation.Add),
                        new OperationNode2(new OperationNodeLeaf(5), new OperationNodeLeaf(6), Operation.Multiply),
                        Operation.Power
                        ),
                    new OperationNode2(
                        new OperationNode2(new OperationNodeLeaf(1), new OperationNodeLeaf(2), Operation.Multiply),
                        new OperationNode1(new OperationNodeLeaf(7, Operation.None), Operation.UnaryMinus),
                        Operation.Add
                        ),
                    Operation.Multiply
                    );
            var visitor = new Visitor();
            visitor.Visit(tree);
            System.Diagnostics.Debug.WriteLine(visitor.Text);
        }
    }
