    public abstract class Expression<T> {
        public abstract T Evaluate();
    }
    public sealed class AddExpression : Expression<int> {
        public AddExpression(Expression<int> left, Expression<int> right) {
            this.Left = left;
            this.Right = right;
        }
        public Expression<int> Left { get; private set; }
        public Expression<int> Right { get; private set; }
        public override int Evaluate() {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
