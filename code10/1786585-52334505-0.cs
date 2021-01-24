     public interface IMyValidator<out T>
        {
            void AddMyRule<TProperty>(Func<T, TProperty> expression, string message);
        }
        public abstract class MyBaseValidator<T> : AbstractValidator<T>, IMyValidator<T>
            {
                public void AddMyRule<TProperty>(Func<T, TProperty> expression, string message)
                {
                    var exp = FuncToExpression(expression);
                    RuleFor(exp).NotEmpty().WithMessage(message);
                }
        
                private static Expression<Func<T, P>> FuncToExpression<T, P>(Func<T, P> f) => x => f(x);
            }
    
    public static class Ext
        {
            public static void ValidateAll<T>(this AbstractValidator<T> validator)
            {
                (validator as IMyValidator<IWithPropertyA>)?.AddMyRule(x => x.PropertyA, "PropA Cant be empty");
                (validator as IMyValidator<IWithPropertyB>)?.AddMyRule(x => x.PropertyB, "PropB Cant be empty");
            }
        }
    
     public class Handler1 : MyBaseValidator<Handler1Data>
        {
            public Handler1()
            {
                this.ValidateAll();
            }
        }
        public class Handler2 : MyBaseValidator<Handler2Data> { }
