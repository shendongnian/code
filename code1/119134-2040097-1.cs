    class ReduceFinder : ExpressionVisitor {
        public override Expression Visit(Expression node) {
            if (node != null && node.CanReduce) {
                var reduced = node.Reduce();
                Console.WriteLine("Found expression to reduce!");
                Console.WriteLine("Before: {0}: {1}", node.GetType().Name, node);
                Console.WriteLine("After: {0}: {1}", reduced.GetType().Name, reduced);
            }
            return base.Visit(node);
        }
    }
    class Foo {
        public int x;
        public int y;
    }
    static class Program {
        static void Main() {
            Expression<Func<int, Foo>> expr = z => new Foo { x = (z + 1), y = (z + 1) };
            new ReduceFinder().Visit(expr);
        }
    }
