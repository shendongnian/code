    public class DisplayOrderableList<T> : List<T>
    {
        #region Private Fields
        private PropertyInfo _property;
        #endregion
        #region Constructors
        public DisplayOrderableList(Expression<Func<T, int>> expression)
        {
            ValidateExpression(expression);
        }
        #endregion
        #region Public Methods
        public void MoveUp(T item)
        {
            if (!Contains(item))
                throw new ArgumentNullException("item", "item doesn't exists in collection");
            var idx = IndexOf(item);
            RemoveAt(idx);
            if (idx > 0)
                Insert(idx - 1, item);
            else
                Insert(0, item);
            UpdateDisplayOrder();
        }
        public void MoveDown(T item)
        {
            if (!Contains(item))
                throw new ArgumentNullException("item", "item doesn't exists in collection");
            var idx = IndexOf(item);
            RemoveAt(idx);
            if (idx + 1 > Count)
                Add(item);
            else
                Insert(idx + 1, item);
            UpdateDisplayOrder();
        }
        #endregion
        #region Private Methods
        private void UpdateDisplayOrder()
        {
            foreach (var item in this)
            {
                _property.SetValue(item, IndexOf(item), null);
            }
        }
        #endregion
        #region Expression Methods
        private void ValidateExpression(Expression<Func<T, int>> expression)
        {
            var lamba = ToLambaExpression(expression);
            var propInfo = ToPropertyInfo(lamba);
            if (!propInfo.CanWrite)
            {
                throw new ArgumentException(String.Format("Property {0} as no setters", propInfo.Name));
            }
            _property = propInfo;
        }
        private static LambdaExpression ToLambaExpression(Expression expression)
        {
            var lambda = expression as LambdaExpression;
            if (lambda == null)
            {
                throw new ArgumentException("Invalid Expression");
            }
            var convert = lambda.Body as UnaryExpression;
            if (convert != null && convert.NodeType == ExpressionType.Convert)
            {
                lambda = Expression.Lambda(convert.Operand, lambda.Parameters.ToArray());
            }
            return lambda;
        }
        private static PropertyInfo ToPropertyInfo(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression", "Expression cannot be null.");
            }
            var prop = expression.Body as MemberExpression;
            if (prop == null)
            {
                throw new ArgumentException("Invalid expression");
            }
            var propInfo = prop.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException("Invalid property");
            }
            return propInfo;
        }
        #endregion
    }
