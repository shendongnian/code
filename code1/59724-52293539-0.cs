    public  static  class PredicateExtensions
    {
         ///  <summary>
         /// Begin an expression chain
         ///  </summary>
         ///  <typeparam id="T""></typeparam>
         ///  <param id="value"">Default return value if the chanin is ended early</param>
         ///  <returns>A lambda expression stub</returns>
         public  static Expression<Func<T,  bool>> Begin<T>(bool value =  false)
        {
             if (value)
                 return parameter =>  true;  //value cannot be used in place of true/false
    
             return parameter =>  false;
        }
    
         public  static Expression<Func<T,  bool>> And<T>(this Expression<Func<T,  bool>> left,
            Expression<Func<T,  bool>> right)
        {
             return CombineLambdas(left, right, ExpressionType.AndAlso);
        }
    
         public  static Expression<Func<T,  bool>> Or<T>(this Expression<Func<T,  bool>> left, Expression<Func<T,  bool>> right)
        {
             return CombineLambdas(left, right, ExpressionType.OrElse);
        }
    
         #region private
    
         private  static Expression<Func<T,  bool>> CombineLambdas<T>(this Expression<Func<T,  bool>> left,
            Expression<Func<T,  bool>> right, ExpressionType expressionType)
        {
             //Remove expressions created with Begin<T>()
             if (IsExpressionBodyConstant(left))
                 return (right);
    
            ParameterExpression p = left.Parameters[0];
    
            SubstituteParameterVisitor visitor =  new SubstituteParameterVisitor();
            visitor.Sub[right.Parameters[0]] = p;
    
            Expression body = Expression.MakeBinary(expressionType, left.Body, visitor.Visit(right.Body));
             return Expression.Lambda<Func<T,  bool>>(body, p);
        }
    
         private  static  bool IsExpressionBodyConstant<T>(Expression<Func<T,  bool>> left)
        {
             return left.Body.NodeType == ExpressionType.Constant;
        }
    
         internal  class SubstituteParameterVisitor : ExpressionVisitor
        {
             public Dictionary<Expression, Expression> Sub =  new Dictionary<Expression, Expression>();
    
             protected  override Expression VisitParameter(ParameterExpression node)
            {
                Expression newValue;
                 if (Sub.TryGetValue(node,  out newValue))
                {
                     return newValue;
                }
                 return node;
            }
        }
    
         #endregion
    } 
