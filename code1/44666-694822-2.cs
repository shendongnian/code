    using System;
    
    namespace ConsoleApplication1
    {
        public interface IExprVisitor<t>
        {
            t Visit(TrueExpr expr);
            t Visit(And expr);
            t Visit(Nand expr);
            t Visit(Or expr);
            t Visit(Xor expr);
            t Visit(Not expr);
    
        }
    
        public abstract class Expr
        {
            public abstract t Accept<t>(IExprVisitor<t> visitor);
        }
    
        public abstract class UnaryOp : Expr
        {
            public Expr First { get; private set; }
            public UnaryOp(Expr first)
            {
                this.First = first;
            }
        }
    
        public abstract class BinExpr : Expr
        {
            public Expr First { get; private set; }
            public Expr Second { get; private set; }
    
            public BinExpr(Expr first, Expr second)
            {
                this.First = first;
                this.Second = second;
            }
        }
    
        public class TrueExpr : Expr
        {
            public override t Accept<t>(IExprVisitor<t> visitor)
            {
                return visitor.Visit(this);
            }
        }
    
        public class And : BinExpr
        {
            public And(Expr first, Expr second) : base(first, second) { }
            public override t Accept<t>(IExprVisitor<t> visitor)
            {
                return visitor.Visit(this);
            }
        }
    
        public class Nand : BinExpr
        {
            public Nand(Expr first, Expr second) : base(first, second) { }
            public override t Accept<t>(IExprVisitor<t> visitor)
            {
                return visitor.Visit(this);
            }
        }
    
        public class Or : BinExpr
        {
            public Or(Expr first, Expr second) : base(first, second) { }
            public override t Accept<t>(IExprVisitor<t> visitor)
            {
                return visitor.Visit(this);
            }
        }
    
        public class Xor : BinExpr
        {
            public Xor(Expr first, Expr second) : base(first, second) { }
            public override t Accept<t>(IExprVisitor<t> visitor)
            {
                return visitor.Visit(this);
            }
        }
    
        public class Not : UnaryOp
        {
            public Not(Expr first) : base(first) { }
            public override t Accept<t>(IExprVisitor<t> visitor)
            {
                return visitor.Visit(this);
            }
        }
    
        public class EvalVisitor : IExprVisitor<bool>
        {
            public bool Visit(TrueExpr expr)
            {
                return true;
            }
    
            public bool Visit(And expr)
            {
                return Eval(expr.First) && Eval(expr.Second);
            }
    
            public bool Visit(Nand expr)
            {
                return !(Eval(expr.First) && Eval(expr.Second));
            }
    
            public bool Visit(Or expr)
            {
                return Eval(expr.First) || Eval(expr.Second);
            }
    
            public bool Visit(Xor expr)
            {
                return Eval(expr.First) ^ Eval(expr.Second);
            }
    
            public bool Visit(Not expr)
            {
                return !Eval(expr.First);
            }
    
            public bool Eval(Expr expr)
            {
                return expr.Accept(this);
            }
        }
    
        public class PrettyPrintVisitor : IExprVisitor<string>
        {
            public string Visit(TrueExpr expr)
            {
                return "True";
            }
    
            public string Visit(And expr)
            {
                return string.Format("({0}) AND ({1})", expr.First.Accept(this), expr.Second.Accept(this));
            }
    
            public string Visit(Nand expr)
            {
                return string.Format("({0}) NAND ({1})", expr.First.Accept(this), expr.Second.Accept(this));
            }
    
            public string Visit(Or expr)
            {
                return string.Format("({0}) OR ({1})", expr.First.Accept(this), expr.Second.Accept(this));
            }
    
            public string Visit(Xor expr)
            {
                return string.Format("({0}) XOR ({1})", expr.First.Accept(this), expr.Second.Accept(this));
            }
    
            public string Visit(Not expr)
            {
                return string.Format("Not ({0})", expr.First.Accept(this));
            }
    
            public string Pretty(Expr expr)
            {
                return expr.Accept(this).Replace("(True)", "True");
            }
        }
    
        class Program
        {
            static void TestLogicalEquivalence(Expr first, Expr second)
            {
                var prettyPrinter = new PrettyPrintVisitor();
                var eval = new EvalVisitor();
                var evalFirst = eval.Eval(first);
                var evalSecond = eval.Eval(second);
    
                Console.WriteLine("Testing expressions:");
                Console.WriteLine("    First  = {0}", prettyPrinter.Pretty(first));
                Console.WriteLine("        Eval(First):  {0}", evalFirst);
                Console.WriteLine("    Second = {0}", prettyPrinter.Pretty(second));
                Console.WriteLine("        Eval(Second): {0}", evalSecond);;
                Console.WriteLine("    Equivalent? {0}", evalFirst == evalSecond);
                Console.WriteLine();
            }
    
            static void Main(string[] args)
            {
                var P = new TrueExpr();
                var Q = new Not(new TrueExpr());
    
                TestLogicalEquivalence(P, Q);
    
                TestLogicalEquivalence(
                    new Not(P),
                    new Nand(P, P));
    
                TestLogicalEquivalence(
                    new And(P, Q),
                    new Nand(new Nand(P, Q), new Nand(P, Q)));
    
                TestLogicalEquivalence(
                    new Or(P, Q),
                    new Nand(new Nand(P, P), new Nand(Q, Q)));
    
                TestLogicalEquivalence(
                    new Xor(P, Q),
                    new Nand(
                        new Nand(P, new Nand(P, Q)),
                        new Nand(Q, new Nand(P, Q)))
                    );
    
                Console.ReadKey(true);
            }
        }
    }
