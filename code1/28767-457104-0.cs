    using System;
    using System.Linq.Expressions;
    class Foo
    {
        public string Name { get; set; }
        static void Main()
        {
            var exp = (LambdaExpression) GetExpression();
            WalkTree(0, exp.Body, exp.Parameters[0]);
            
        }
        static void WriteLine(int offset, string message)
        {
            Console.WriteLine(new string('>',offset) + message);
        }
        static void WalkTree(int offset, Expression current,
            ParameterExpression param)
        {
            WriteLine(offset, "Node: " + current.NodeType.ToString());
            switch (current.NodeType)
            {
                case ExpressionType.Constant:
                    WriteLine(offset, "Constant (non-db)"
                        + current.Type.FullName);
                    break;
                case ExpressionType.Parameter:
                    if (!ReferenceEquals(param, current))
                    {
                        throw new InvalidOperationException(
                            "Unexpected parameter: " + param.Name);
                    }
                    WriteLine(offset, "db row: " + param.Name);
                    break;
                case ExpressionType.Equal:
                    BinaryExpression be = (BinaryExpression)current;
                    WriteLine(offset, "Left:");
                    WalkTree(offset + 1, be.Left, param);
                    WriteLine(offset, "Right:");
                    WalkTree(offset + 1, be.Right, param);
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression me = (MemberExpression)current;
                    WriteLine(offset, "Member: " + me.Member.Name);
                    WalkTree(offset + 1, me.Expression, param);
                    break;
                default:
                    throw new NotSupportedException(
                        current.NodeType.ToString());
            }
        }
    
        static Expression<Func<Foo, bool>> GetExpression()
        {
            Foo foo = new Foo { Name = "abc" };
    
            return row => row.Name == foo.Name;
        }    
    }
