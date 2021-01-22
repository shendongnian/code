    public class PlusNode : BinaryNode
    {
        public PlusNode(Node left, Node right) { base(left, right); }
        public virtual double Evaluate() { return Left.Evaluate() + Right.Evaluate(); }
        public virtual Node BuildDerivative()
        {
            return new PlusNode(Left.BuildDerivative(), Right.BuildDerivative());
        }
    }
    public class SinNode : UnaryNode
    {
        public SinNode(Node child) { base(child); }
        public virtual double Evaluate() { return Math.Sin(Child.Evaluate()); }
        public virtual Node BuildDerivative()
        {
            return new MultiplyNode(new CosNode(Child.Clone()), Child.BuildDerivative()); //chain rule
        }
    }
