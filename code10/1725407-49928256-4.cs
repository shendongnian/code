    public static class ExpressionExt {
        public static T Embed<T>(this Expression e) {
            return default(T);
        }
    
        public static Expression ExpandEmbed(this Expression orig) => new EmbedVisitor().Visit(orig);
    
        public static T Evaluate<T>(this Expression e) {
            //A little optimization for constant expressions
            if (e.NodeType == ExpressionType.Constant)
                return (T)((ConstantExpression)e).Value;
            else
                return (T)Expression.Lambda(e).Compile().DynamicInvoke();
        }
    }
