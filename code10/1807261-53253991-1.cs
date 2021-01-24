    public class TestRuleWithExtension : RuleBase
    {
        public override void Define()
        {
            base.Define();
            Apple apple = null;
            When()
                .Match(() => apple);
            Then()
                .AddToBasket(() => apple);
        }
    }
    public static class DslExtensions
    {
        public static IRightHandSideExpression AddToBasket(this IRightHandSideExpression rhs, Expression<Func<IFruit>> alias)
        {
            var context = Expression.Parameter(typeof(IContext), "ctx");
            var ctor = typeof(Basket).GetConstructor(new[] {typeof(IFruit)});
            var newBasket = Expression.New(ctor, alias.Body);
            var action = Expression.Lambda<Action<IContext>>(
                Expression.Call(context, nameof(IContext.Insert), null, newBasket), 
                context);
            return rhs.Do(action);
        }
    }
