        [TestFixture]
    public class TestClass
    {
        [Test]
        public void TEst()
        {
            var user = new User {Id = 123};
            var idToSearch = user.Id;
            var query = Creator.CreateQuery<User>()
                .Where(x => x.Id == idToSearch);
        }
    }
    public class Query<T>
    {
        public Query<T> Where(Expression<Func<T, object>> filter)
        {
            var rightValue = GenericHelper.GetVariableValue(((BinaryExpression)((UnaryExpression)filter.Body).Operand).Right.Type, ((BinaryExpression)((UnaryExpression)filter.Body).Operand).Right);
            Console.WriteLine(rightValue);
            return this;
        }
    }
    internal class GenericHelper
    {
        internal static object GetVariableValue(Type variableType, Expression expression)
        {
            var targetMethodInfo = typeof(InvokeGeneric).GetMethod("GetVariableValue");
            var genericTargetCall = targetMethodInfo.MakeGenericMethod(variableType);
            return genericTargetCall.Invoke(new InvokeGeneric(), new[] { expression });
        }
    }
    internal class InvokeGeneric
    {
        public T GetVariableValue<T>(Expression expression) where T : class
        {
            var accessorExpression = Expression.Lambda<Func<T>>(expression);
            var accessor = accessorExpression.Compile();
            return accessor();
        }
    }
