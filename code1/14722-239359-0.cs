    public class Class1
    {
        public string Selection { get; set; }
        public void Sample()
        {
            Selection = "Example";
            Example<Book, bool>(p => p.Title == Selection);
        }
        public void Example<T,TResult>(Expression<Func<T,TResult>> exp)
        {
            BinaryExpression equality = (BinaryExpression)exp.Body;
            Debug.Assert(equality.NodeType == ExpressionType.Equal);
            // Note that you need to know the type of the rhs of the equality
            var accessorExpression = Expression.Lambda<Func<string>>(equality.Right);
            Func<string> accessor = accessorExpression.Compile();
            var value = accessor();
            Debug.Assert(value == Selection);
        }
    }
    public class Book
    {
        public string Title { get; set; }
    }
